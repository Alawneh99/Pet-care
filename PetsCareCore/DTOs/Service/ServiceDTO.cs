﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.DTOs.Service
{
    public class ServiceDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Duration { get; set; }
        public string? Image { get; set; }
    }
}