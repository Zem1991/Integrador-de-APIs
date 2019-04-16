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
    [Route("instagram/comment")]
    [ApiController]
    public class InstagramCommentController : ControllerBase
    {
        [HttpGet("media/{mediaId}")]
        public async Task<List<InstagramComment>> GetMediaComments(string mediaId, [FromQuery] string accessToken)
        {
            InstagramCommentAAO aao = new InstagramCommentAAO();
            List<InstagramComment> result = await aao.GetMediaComments(mediaId, accessToken);
            return result;
        }

        [HttpGet("user/{userId}")]
        public async Task<List<InstagramComment>> GetUserReceivedComments(string userId, [FromQuery] string accessToken)
        {
            InstagramCommentAAO aao = new InstagramCommentAAO();
            List<InstagramComment> result = await aao.GetUserReceivedComments(userId, accessToken);
            return result;
        }
    }
}