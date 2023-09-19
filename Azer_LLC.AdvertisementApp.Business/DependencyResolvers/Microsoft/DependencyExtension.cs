using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azer_LLC.AdvertisementApp.Business.Interfaces;
using Azer_LLC.AdvertisementApp.Business.Mappings.AutoMapper;
using Azer_LLC.AdvertisementApp.Business.Services;
using Azer_LLC.AdvertisementApp.Business.ValidationRules;
using Azer_LLC.AdvertisementApp.DataAccess.Contexts;
using Azer_LLC.AdvertisementApp.DataAccess.UnitOfWork;
using Azer_LLC.AdvertisementApp.Dtos;

namespace Azer_LLC.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddAutoMapper(typeof(ProvidedServiceProfile));
            services.AddAutoMapper(typeof(AdvertisementProfile));
            services.AddAutoMapper(typeof(AppUserProfile)); 
            services.AddAutoMapper(typeof(GenderProfile));
            services.AddAutoMapper(typeof(AdvertisementAppUserStatusProfile));
            services.AddAutoMapper(typeof(AdvertisementAppUserProfile));
            services.AddAutoMapper(typeof(AppRoleProfile));
            services.AddAutoMapper(typeof(MilitaryStatusProfile));

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();

        }
    }
}
