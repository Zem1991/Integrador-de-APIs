using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/product")]
    [ApiController]
    public class MeliProductController : ControllerBase
    {
        [HttpGet("{productId}")]
        public async Task<MeliProduct> Get(string productId, [FromQuery] string accessToken)
        {
            MeliProductAAO aao = new MeliProductAAO();
            MeliProduct result = await aao.Get(productId, accessToken);
            return result;
        }

        [HttpGet("user/me")]
        public async Task<List<MeliProduct>> GetMyProducts([FromQuery] string accessToken)
        {
            MeliProductAAO aao = new MeliProductAAO();
            List<MeliProduct> result = await aao.GetMyProducts(accessToken);
            return result;
        }

        [HttpGet("user/{userId}")]
        public async Task<List<MeliProduct>> GetUserProducts(string userId, [FromQuery] string accessToken)
        {
            MeliProductAAO aao = new MeliProductAAO();
            List<MeliProduct> result = await aao.GetUserProducts(userId, accessToken);
            return result;
        }
    }
}
