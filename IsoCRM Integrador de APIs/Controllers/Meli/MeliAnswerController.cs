using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/answer")]
    [ApiController]
    public class MeliAnswerController : ControllerBase
    {
        [HttpPost("{questionId}")]
        public void Post([FromBody] string body, [FromQuery] string accessToken)
        {
        }
    }
}