using API.Core.DbModels.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.JWTUtility
{
    public interface IJwtService
    {
        JwtToken GenerateJWTToken(AppUser appUser);
    }
}
