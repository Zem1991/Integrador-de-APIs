using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HttpParamsUtility;
using MercadoLibre.SDK;
using MercadoLibre.SDK.Meta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IsoCRM_Integrador_de_APIs.APIs.Meli
{
    public static class MeliApiCaller
    {
        private const long appId = 550009235470605;
        private const string appSecret = "RKhSbBQGn8jyoGxaBUrcvVSpPfFhmsJo";

        public enum Method
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public static async Task<T> Call<T>(Method method, string endpoint, HttpParams callParams, object callBody)
        {
            MeliApiService api = getMeliApiService();
            HttpResponseMessage response = null;
            switch (method)
            {
                case Method.GET:
                    response = await api.GetAsync(endpoint, callParams);
                    break;
                case Method.POST:
                    response = await api.PostAsync(endpoint, callParams, callBody);
                    break;
                case Method.PUT:
                    response = await api.PutAsync(endpoint, callParams, callBody);
                    break;
                case Method.DELETE:
                    response = await api.DeleteAsync(endpoint, callParams);
                    break;
            }
            return await ParseResponse<T>(response);
        }

        private static MeliApiService getMeliApiService()
        {
            return new MeliApiService
            {
                Credentials = new MeliCredentials(MeliSite.Brasil, appId, appSecret)
            };
        }

        private static async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            else
            {
                MeliApiError result = JsonConvert.DeserializeObject<MeliApiError>(json);
                throw new ApiResponseException(result.status, result.error, result.message, result.cause);
            }
        }
    }
}
