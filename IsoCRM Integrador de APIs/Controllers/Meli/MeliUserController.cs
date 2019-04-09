using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/user")]
    [ApiController]
    public class MeliUserController : ControllerBase
    {
        [HttpGet("me")]
        public async Task<MeliUser> GetMe([FromQuery] string accessToken)
        {
            MeliUserAAO aao = new MeliUserAAO();
            MeliUser result = await aao.GetMe(accessToken);
            return result;
        }

        [HttpGet("{userId}")]
        public async Task<MeliUser> Get(string userId, [FromQuery] string accessToken)
        {
            MeliUserAAO aao = new MeliUserAAO();
            MeliUser result = await aao.Get(userId, accessToken);
            return result;
        }
    }
}
