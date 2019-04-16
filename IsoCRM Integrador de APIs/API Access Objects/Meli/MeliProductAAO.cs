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
    public class MeliProductAAO
    {
        public async Task<MeliProduct> Get(string productId, string accessToken)
        {
            Method method = Method.GET;
            string endpoint = "items/" + productId;
            endpoint += "?access_token=" + accessToken;

            MeliApiCaller caller = new MeliApiCaller();
            MeliProduct result = await caller.Call<MeliProduct>(method, endpoint);
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
            Method method = Method.GET;
            string endpoint = "users/" + userId + "/items/search";
            endpoint += "?access_token=" + accessToken;

            MeliApiCaller caller = new MeliApiCaller();
            MeliUserProducts intermediateResult = await caller.Call<MeliUserProducts>(method, endpoint);

            List<MeliProduct> result = new List<MeliProduct>();
            foreach (string productId in intermediateResult.Results)
            {
                MeliProduct product = Get(productId, accessToken).Result;
                result.Add(product);
            }
            return result;
        }
    }
    internal class MeliUserProducts
    {
        public string Seller_id { get; set; }
        public string[] Results { get; set; }
    }
}
