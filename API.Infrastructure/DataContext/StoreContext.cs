using API.Core.DbModels;
using API.Core.DbModels.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.DataContext
{
    public class StoreContext: IdentityDbContext<AppUser>
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }


    }
}
