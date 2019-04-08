using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.APIs;
using IsoCRM_Integrador_de_APIs.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/user")]
    [ApiController]
    public class MeliUserController : ControllerBase
    {
        [HttpGet("me")]
        public IEnumerable<string> GetMe([FromQuery] string accessToken)
        {
            List<string> causes = new List<string>();
            causes.Add("cause 1");
            causes.Add("cause 2");
            causes.Add("cause 3");
            causes.Add("cause D");
            throw new ApiResponseException("500", "machine error", "human error", causes);
            return Get("me", accessToken);
        }

        [HttpGet("{userId}")]
        public IEnumerable<string> Get(string userId, [FromQuery] string accessToken)
        {
            return new string[] { "user " + userId };
        }
    }
}
