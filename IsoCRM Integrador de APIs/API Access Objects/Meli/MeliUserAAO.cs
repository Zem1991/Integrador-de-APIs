using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.APIs;
using IsoCRM_Integrador_de_APIs.APIs.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli
{
    public class MeliUserAAO
    {
        public async Task<MeliUser> GetMe(string accessToken)
        {
            return await Get("me", accessToken);
        }

        public async Task<MeliUser> Get(string userId, string accessToken)
        {
            Method method = Method.GET;
            string endpoint = "/users/" + userId;
            endpoint += "?access_token=" + accessToken;

            MeliApiCaller caller = new MeliApiCaller();
            MeliUser result = await caller.Call<MeliUser>(method, endpoint);
    	    return result;
        }
    }
}
