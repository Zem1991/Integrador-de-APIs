using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs.Facebook
{
    public class FacebookApiCaller : GenericApiCaller
    {
        public override string ApiUri(string endpoint = null)
        {
            return "https://graph.facebook.com/" + endpoint;
        }

        public override void ThrowApiException(string responseAsJson)
        {
            JObject jobj = JObject.Parse(responseAsJson);
            string error = jobj["error"].ToString();

            FacebookApiError result = JsonConvert.DeserializeObject<FacebookApiError>(error);
            string errorCode = result.code + (result.error_subcode != null ? "/" + result.error_subcode : "");
            throw new ApiResponseException("Facebook", errorCode, result.type, result.message, null);
        }
    }
}
