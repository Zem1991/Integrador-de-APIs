using System;
using System.Collections.Generic;
using IsoCRM_Integrador_de_APIs.APIs;
using IsoCRM_Integrador_de_APIs.Models.Facebook;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Facebook
{
    public class FacebookUserAAO
    {
        public async Task<FacebookUser> GetMe(string accessToken)
        {
            return await Get("me", accessToken);
        }

        public async Task<FacebookUser> Get(string userId, string accessToken)
        {
            ApiCaller.Method method = ApiCaller.Method.GET;
            string apiUri = "";
            string endpoint = "/" + userId + "?fields=id,name,picture";

            object requestParams = new
            {
                accessToken
            };
            string jsonContent = JsonConvert.SerializeObject(requestParams);
            StringContent content = new StringContent(jsonContent);

            FacebookUser result = await ApiCaller.Call<FacebookUser>(method, apiUri, endpoint, content);
    	    return result;
        }
    }
}
