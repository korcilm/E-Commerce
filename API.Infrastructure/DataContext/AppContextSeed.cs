using API.Core.DbModels.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.DataContext
{
    public class AppContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Muhammet",
                    Email = "mkorcil@gmail.com",
                    UserName = "mkorcil",
                    Address = new Address
                    {
                        FirstName = "Muahmmet",
                        LastName = "Korçil",
                        Street = "Beylikbağı",
                        City = "Kocaeli",
                        State = "TR",
                        ZipCode = "41000"
                    }
                };
                await userManager.CreateAsync(user, "Test.123");

            }
        }
    }
}
