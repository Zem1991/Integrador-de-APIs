using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs
{
    public class GenericApiCaller : IApiCaller
    {
        public virtual string ApiUri(string endpoint = null)
        {
            return "/" + endpoint;
        }

        public virtual async Task<T> Call<T>(Method method, string endpoint, string requestBody = null)
        {
            HttpClient caller = new HttpClient();
            string uri = ApiUri(endpoint);
            StringContent content = (string.IsNullOrEmpty(requestBody) ? null : new StringContent(requestBody));

            HttpResponseMessage response = null;
            switch (method)
            {
                case Method.GET:
                    response = await caller.GetAsync(uri);
                    break;
                case Method.POST:
                    response = await caller.PostAsync(uri, content);
                    break;
                case Method.PUT:
                    response = await caller.PutAsync(uri, content);
                    break;
                case Method.DELETE:
                    response = await caller.DeleteAsync(uri);
                    break;
            }
            return await ParseResponse<T>(response);
        }

        public virtual async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                ThrowApiResponseException(json);
            }
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public virtual void ThrowApiResponseException(string responseAsJson)
        {
            List<string> cause = new List<string>
            {
                responseAsJson
            };
            throw new ApiResponseException("Generic API", "No known error code", "No known error type", "No known feedback message", cause);
        }
    }
}
