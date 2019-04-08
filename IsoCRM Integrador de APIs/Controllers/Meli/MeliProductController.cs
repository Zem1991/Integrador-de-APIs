using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/product")]
    [ApiController]
    public class MeliProductController : ControllerBase
    {
        [HttpGet("{productId}")]
        public string Get(string productId, [FromQuery] string accessToken)
        {
            return "product of id " + productId;
        }

        [HttpGet("user/{userId}")]
        public IEnumerable<string> GetByUser(string userId, [FromQuery] string accessToken)
        {
            return new string[] { "product 1 from user " + userId, "product 2 from user " + userId };
        }
    }
}