﻿using Azer_LLC.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azer_LLC.AdvertisementApp.Dtos
{
    public class MilitaryStatusListDto : IDto
    {
        public int Id { get; set; }

        public string Definition { get; set; }
    }
}
