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
    public class MeliProductAAO
    {
        public async Task<MeliProduct> Get(string productId, string accessToken)
        {
            MeliApiCaller.Method method = MeliApiCaller.Method.GET;
            string endpoint = "/items/" + productId;
            HttpParamsUtility.HttpParams callParams = new HttpParamsUtility.HttpParams()
                .Add("access_token", accessToken);

            MeliProduct result = await MeliApiCaller.Call<MeliProduct>(method, endpoint, callParams);
            return result;
        }

        public async Task<List<MeliProduct>> GetMyProducts(string accessToken)
        {
            MeliUserAAO aao = new MeliUserAAO();
            MeliUser result = await aao.GetMe(accessToken);
            return await GetUserProducts(result.id, accessToken);
        }

        public async Task<List<MeliProduct>> GetUserProducts(string userId, string accessToken)
        {
            MeliApiCaller.Method method = MeliApiCaller.Method.GET;
            string endpoint = "/users/" + userId + "/items/search";
            HttpParamsUtility.HttpParams callParams = new HttpParamsUtility.HttpParams()
                .Add("access_token", accessToken);

            MeliUserProducts intermediateResult = await MeliApiCaller.Call<MeliUserProducts>(method, endpoint, callParams);

            List<MeliProduct> result = new List<MeliProduct>();
            foreach (string productId in intermediateResult.results)
            {
                MeliProduct product = Get(productId, accessToken).Result;
                result.Add(product);
            }
            return result;
        }
    }
    public class MeliUserProducts
    {
        public string seller_id { get; set; }
        public string[] results { get; set; }
    }
}
