using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            MeliApiCaller.Method method = MeliApiCaller.Method.GET;
            string endpoint = "/users/" + userId;
            HttpParamsUtility.HttpParams callParams = new HttpParamsUtility.HttpParams()
                .Add("access_token", accessToken);

            MeliUser result = await MeliApiCaller.Call<MeliUser>(method, endpoint, callParams);
    	    return result;
        }
    }
}
