using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Instagram;
using IsoCRM_Integrador_de_APIs.Models.Instagram;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Instagram
{
    [Route("instagram/media")]
    [ApiController]
    public class InstagramMediaController : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<List<InstagramMedia>> GetUserMedia(string userId, [FromQuery] string accessToken)
        {
            InstagramMediaAAO aao = new InstagramMediaAAO();
            List<InstagramMedia> result = await aao.GetUserMedia(userId, accessToken);
            return result;
        }
    }
}