using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correios.CorreiosServiceReference;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Correios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Correios
{
    [Route("correios/cliente")]
    [ApiController]
    public class CorreiosClienteController : ControllerBase
    {
        [HttpPost()]
        public async Task<clienteERP> Get([FromBody] Dictionary<string, string> callBody)
        {
            CorreiosClienteAAO aao = new CorreiosClienteAAO();
            clienteERP result = await aao.Get(callBody);
            return result;
        }
    }
}