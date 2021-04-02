﻿using API.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.DataContext
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }


    }
}
