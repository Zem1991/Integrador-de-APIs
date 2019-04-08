using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.Controllers.Meli
{
    [Route("meli/question")]
    [ApiController]
    public class MeliQuestionController : ControllerBase
    {
        [HttpGet("{questionId}")]
        public string Get(string questionId, [FromQuery] string accessToken)
        {
            return "question of id " + questionId;
        }

        [HttpGet("product/{productId}")]
        public IEnumerable<string> GetByProduct(string productId, [FromQuery] string accessToken)
        {
            return new string[] { "question 1 from product " + productId, "question 2 from product " + productId };
        }

        [HttpGet("user/{userId}")]
        public IEnumerable<string> GetByUser(string userId, [FromQuery] string accessToken)
        {
            return new string[] { "question 1 from user " + userId, "question 2 from user " + userId };
        }
    }
}