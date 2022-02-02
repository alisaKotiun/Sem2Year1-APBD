using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial9.DTOs.Response
{
    public class TokenResponseDto
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
