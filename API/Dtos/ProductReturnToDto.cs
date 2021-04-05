﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductReturnToDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public decimal? Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}
