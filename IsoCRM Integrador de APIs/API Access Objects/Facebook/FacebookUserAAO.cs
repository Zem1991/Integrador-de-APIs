using System;
using System.Collections.Generic;
using IsoCRM_Integrador_de_APIs.APIs;
using IsoCRM_Integrador_de_APIs.APIs.Facebook;
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
            Method method = Method.GET;
            string endpoint = userId + "?fields=id,name,picture";
            endpoint += "&access_token=" + accessToken;

            FacebookApiCaller caller = new FacebookApiCaller();
            FacebookUser result = await caller.Call<FacebookUser>(method, endpoint);
            return result;
        }
    }
}
