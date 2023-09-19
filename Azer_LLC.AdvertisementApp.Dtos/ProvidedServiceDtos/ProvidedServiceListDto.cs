using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azer_LLC.AdvertisementApp.Dtos.Interfaces;

namespace Azer_LLC.AdvertisementApp.Dtos
{
    public class ProvidedServiceCreateDto:IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
