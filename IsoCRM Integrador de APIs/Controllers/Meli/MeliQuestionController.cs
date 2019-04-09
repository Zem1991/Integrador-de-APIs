using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/question")]
    [ApiController]
    public class MeliQuestionController : ControllerBase
    {
        [HttpGet("user/me")]
        public async Task<List<MeliQuestion>> GetMyReceivedQuestions([FromQuery] string accessToken)
        {
            MeliQuestionAAO aao = new MeliQuestionAAO();
            List<MeliQuestion> result = await aao.GetMyReceivedQuestions(accessToken);
            return result;
        }

        [HttpGet("user/{userId}")]
        public async Task<List<MeliQuestion>> GetUserReceivedQuestions(string userId, [FromQuery] string accessToken)
        {
            MeliQuestionAAO aao = new MeliQuestionAAO();
            List<MeliQuestion> result = await aao.GetUserReceivedQuestions(userId, accessToken);
            return result;
        }
    }
}
