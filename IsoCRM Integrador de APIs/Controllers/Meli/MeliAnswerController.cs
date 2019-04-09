using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/answer")]
    [ApiController]
    public class MeliAnswerController : ControllerBase
    {
        [HttpPost]
        public async Task<MeliQuestion> Post([FromBody] Dictionary<string, string> callBody, [FromQuery] string accessToken)
        {
            MeliAnswerAAO aao = new MeliAnswerAAO();
            MeliQuestion result = await aao.Post(callBody, accessToken);
            return result;
        }
    }
}
