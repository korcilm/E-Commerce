using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels.Identity
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
