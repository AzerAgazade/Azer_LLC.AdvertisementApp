using Azer_LLC.AdvertisementApp.Business.Interfaces;
using Azer_LLC.AdvertisementApp.Common.Enums;
using Azer_LLC.AdvertisementApp.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Azer_LLC.AdvertisementApp.UI.Models;
using System.Security.Claims;
using Azer_LLC.AdvertisementApp.Common;
using Azer_LLC.AdvertisementApp.Dtos.Interfaces;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using PdfDocument = PdfSharp.Pdf.PdfDocument;
using PdfReader = PdfSharp.Pdf.IO.PdfReader;
using PdfPage = PdfSharp.Pdf.PdfPage;

namespace Azer_LLC.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;

        public AdvertisementController(IAppUserService appUserService, IAdvertisementAppUserService advertisementAppUserService)
        {
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementAppUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);

            ViewBag.GenderId = userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));

            var list = new List<MilitaryStatusListDto>();

            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            return View(new AdvertisementAppUserCreateModel
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            });
        }


        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = new();
            if (model.CvFile != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.CvFile.CopyToAsync(stream);
                    dto.CvPath = path;
                }
            }

            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.AdvertisementId = model.AdvertisementId;
            dto.AppUserId = model.AppUserId;
            dto.EndDate = model.EndDate;
            dto.MilitaryStatusId = model.MilitaryStatusId;
            dto.WorkExperience = model.WorkExperience;

            var response = await _advertisementAppUserService.CreateAsync(dto);
            if (response.ResponseType == Common.ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);

                ViewBag.GenderId = userResponse.Data.GenderId;

                var items = Enum.GetValues(typeof(MilitaryStatusType));

                var list = new List<MilitaryStatusListDto>();

                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                    });
                }

                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

                return View(model);
            }
            else
            {
                return RedirectToAction("HumanResource", "Home");
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Apply);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            await _advertisementAppUserService.SetStatusAsync(advertisementAppUserId, type);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovedList()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Interview);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectedList()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Negative);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DownloadCv(string CvPath, string Firstname, string Surname)
        {
            if (!System.IO.File.Exists(CvPath))
            {
                return NotFound();
            }

            // Open the existing PDF document
            PdfDocument pdfDoc = PdfReader.Open(CvPath, PdfDocumentOpenMode.Modify);

            // Create a memory stream to store the PDF content
            MemoryStream pdfStream = new MemoryStream();

            // Save the existing PDF document to the memory stream
            pdfDoc.Save(pdfStream, false);

            // Return the PDF file for download
            return File(pdfStream.ToArray(), "application/pdf", $"{Firstname}.{Surname}.pdf");

        }
    }
}
