﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Decription { get; set; }
        public decimal? Price { get; set; }
        public string PictureUrl { get; set; }

        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
       

        public int? ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        

    }
}
