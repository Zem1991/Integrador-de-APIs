using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Integrador;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using IsoCRM_Integrador_de_APIs.Models.Integrador;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Integrador
{
    [Route("integrador/mensagempendente")]
    [ApiController]
    public class IntegradorMensagemPendenteController : ControllerBase
    {
        [HttpPost("list")]
        public async Task<List<IntegradorMensagemPendente>> GetMensagensPendentes([FromBody] Dictionary<string, string> callBody)
        {
            IntegradorMensagemPendenteAAO aao = new IntegradorMensagemPendenteAAO();
            List<IntegradorMensagemPendente> result = await aao.GetMensagensPendentes(callBody);
            return result;
        }

        [HttpPost("answer")]
        public async Task<bool> PostAnswer([FromBody] Dictionary<string, string> callBody)
        {
            IntegradorMensagemPendenteAAO aao = new IntegradorMensagemPendenteAAO();
            bool result = await aao.PostAnswer(callBody);
            return result;
        }
    }
}