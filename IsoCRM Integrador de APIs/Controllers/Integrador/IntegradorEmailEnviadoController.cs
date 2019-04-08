using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Integrador
{
    [Route("integrador/emailenviado")]
    [ApiController]
    public class IntegradorEmailEnviadoController : ControllerBase
    {
        [HttpPost("list")]
        public void PostToGetList([FromBody] string body)
        {
        }

        [HttpPost("answer")]
        public void PostAnswer([FromBody] string body)
        {
        }
    }
}