using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs
{
    public static class ApiCaller
    {
        public enum Method
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public static async Task<T> Call<T>(Method method, string apiUri, string endpoint, HttpContent content = null)
        {
            HttpClient caller = new HttpClient();
            string requestUri = apiUri + endpoint;

            HttpResponseMessage response = null;
            switch (method)
            {
                case Method.GET:
                    response = await caller.GetAsync(requestUri);
                    break;
                case Method.POST:
                    response = await caller.PostAsync(requestUri, content);
                    break;
                case Method.PUT:
                    response = await caller.PutAsync(requestUri, content);
                    break;
                case Method.DELETE:
                    response = await caller.DeleteAsync(requestUri);
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
                throw new ApiResponseException("Generic API", "No known status", "No known error", "No feedback message", null);
            }
        }
    }
}
