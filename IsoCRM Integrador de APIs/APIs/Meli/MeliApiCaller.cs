using HttpParamsUtility;
using MercadoLibre.SDK;
using MercadoLibre.SDK.Meta;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs.Meli
{
    public static class MeliApiCaller
    {
        private const long appId = 500830441610727;
        private const string appSecret = "WyIF4565sM9ZMXr4M8ICrSAG6XdCXApF";

        public enum Method
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public static async Task<T> Call<T>(Method method, string endpoint, HttpParams callParams, object callBody = null)
        {
            MeliApiService caller = new MeliApiService
            {
                Credentials = new MeliCredentials(MeliSite.Brasil, appId, appSecret)
            };

            HttpResponseMessage response = null;
            switch (method)
            {
                case Method.GET:
                    response = await caller.GetAsync(endpoint, callParams);
                    break;
                case Method.POST:
                    response = await caller.PostAsync(endpoint, callParams, callBody);
                    break;
                case Method.PUT:
                    response = await caller.PutAsync(endpoint, callParams, callBody);
                    break;
                case Method.DELETE:
                    response = await caller.DeleteAsync(endpoint, callParams);
                    break;
            }
            return await ParseResponse<T>(response);
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
                throw new ApiResponseException("MercadoLivre", result.status, result.error, result.message, result.cause);
            }
        }
    }
}
