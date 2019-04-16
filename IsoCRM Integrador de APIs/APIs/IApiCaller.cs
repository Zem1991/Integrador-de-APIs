using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs
{
    public enum Method
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public interface IApiCaller
    {
        string ApiUri(string endpoint = null);

        Task<T> Call<T>(Method method, string endpoint, string requestBody = null);

        Task<T> ParseResponse<T>(HttpResponseMessage response);

        void ThrowApiException(string responseAsJson);
    }
}
