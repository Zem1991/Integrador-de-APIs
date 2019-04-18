using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Correios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Correios
{
    [Route("correios/postagem")]
    [ApiController]
    public class CorreiosPostagemController : ControllerBase
    {
        [HttpPost("codigopostagem")]
        public async Task<string[]> GetCodigosPostagem([FromBody] Dictionary<string, string> callBody)
        {
            CorreiosPostagemAAO aao = new CorreiosPostagemAAO();
            string[] result = await aao.GetCodigosPostagem(callBody);
            return result;
        }
    }
}