using API.Core.DbModels.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
