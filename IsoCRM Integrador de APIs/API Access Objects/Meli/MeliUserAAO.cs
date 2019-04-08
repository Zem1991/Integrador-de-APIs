using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli
{
    public class MeliUserAAO
    {
        [HttpGet("me")]
        public IEnumerable<string> GetMe([FromQuery] string accessToken)
        {
            return Get("me", accessToken);
        }

        [HttpGet("{userId}")]
        public IEnumerable<string> Get(string userId, [FromQuery] string accessToken)
        {
            return new string[] { "user " + userId };
        }
    }
}
