using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Facebook;
using IsoCRM_Integrador_de_APIs.Models.Facebook;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Facebook
{
    [Route("facebook/user")]
    [ApiController]
    public class FacebookUserController : ControllerBase
    {
        [HttpGet("me")]
        public async Task<FacebookUser> GetMe([FromQuery] string accessToken)
        {
            FacebookUserAAO aao = new FacebookUserAAO();
            FacebookUser result = await aao.GetMe(accessToken);
            return result;
        }
    }
}
