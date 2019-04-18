using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.APIs.Meli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/notification")]
    [ApiController]
    public class MeliNotificationController : ControllerBase
    {
        [HttpPost]
        public async Task<MeliNotification> Notify([FromBody] Dictionary<string, string> callBody)
        {
            MeliNotificationAAO aao = new MeliNotificationAAO();
            MeliNotification result = await aao.Notify(callBody);
            return result;
        }
    }
}