using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Facebook;
using IsoCRM_Integrador_de_APIs.Models.Facebook;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Facebook
{
    [Route("facebook/page")]
    [ApiController]
    public class FacebookPageController : ControllerBase
    {
        [HttpGet]
        public async Task<List<FacebookPage>> GetMyFacebookPages([FromQuery] string accessToken)
        {
            FacebookPageAAO aao = new FacebookPageAAO();
            List<FacebookPage> result = await aao.GetMyFacebookPages(accessToken);
            return result;
        }
    }
}