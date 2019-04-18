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
    [Route("correios/endereco")]
    [ApiController]
    public class CorreiosEnderecoController : ControllerBase
    {
        [HttpGet("{cep}")]
        public async Task<enderecoERP> Get(string cep)
        {
            CorreiosEnderecoAAO aao = new CorreiosEnderecoAAO();
            enderecoERP result = await aao.Get(cep);
            return result;
        }
    }
}