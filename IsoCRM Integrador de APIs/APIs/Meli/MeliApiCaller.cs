using MercadoLibre.SDK;
using MercadoLibre.SDK.Meta;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs.Meli
{
    public class MeliApiCaller : IApiCaller
    {
        private const MeliSite appSite = MeliSite.Brasil;
        private const long appId = 500830441610727;
        private const string appSecret = "WyIF4565sM9ZMXr4M8ICrSAG6XdCXApF";

        public string ApiUri(string endpoint = null)
        {
            string result = appSite.ToDomain();
            if (!string.IsNullOrEmpty(endpoint))
            {
                result += "/" + endpoint;
            }
            return result;
        }

        public async Task<T> Call<T>(Method method, string endpoint, string requestBody = null)
        {
            MeliApiService caller = CreateMeliApiService();

            HttpResponseMessage response = null;
            switch (method)
            {
                case Method.GET:
                    response = await caller.GetAsync(endpoint);
                    break;
                case Method.POST:
                    response = await caller.PostAsync(endpoint, null, requestBody);
                    break;
                case Method.PUT:
                    response = await caller.PutAsync(endpoint, null, requestBody);
                    break;
                case Method.DELETE:
                    response = await caller.DeleteAsync(endpoint);
                    break;
            }
            return await ParseResponse<T>(response);
        }

        public async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                ThrowApiResponseException(json);
            }
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public void ThrowApiResponseException(string responseAsJson)
        {
            MeliApiError result = JsonConvert.DeserializeObject<MeliApiError>(responseAsJson);
            throw new ApiResponseException("MercadoLivre", result.status, result.error, result.message, result.cause);
        }

        private MeliApiService CreateMeliApiService()
        {
            return new MeliApiService
            {
                Credentials = new MeliCredentials(appSite, appId, appSecret)
            };
        }
    }
}
