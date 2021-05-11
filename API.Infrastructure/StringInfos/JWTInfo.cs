using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.StringInfos
{
    namespace ECommerceWithAngular.Infrastructure.StringInfos
    {
        public class JWTInfo
        {
            public string Issuer { get; set; } = "https://localhost:44377";
            public string Audience { get; set; } = "http://localhost:4200";
            public string SecurityKey { get; set; } = "mySuperKey12345678";
            public double TokenExpiration { get; set; } = 5;
        }
    }
}
