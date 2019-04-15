using IsoCRM_Integrador_de_APIs.APIs;
using IsoCRM_Integrador_de_APIs.Models;
using IsoCRM_Integrador_de_APIs.Models.Instagram;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Instagram
{
    public class InstagramMediaAAO
    {
        public async Task<InstagramMedia> GetMedia(string mediaId, string accessToken)
        {
            ApiCaller.Method method = ApiCaller.Method.GET;
            string apiUri = "";
            string endpoint = "/" + mediaId;

            object requestParams = new
            {
                accessToken
            };
            string jsonContent = JsonConvert.SerializeObject(requestParams);
            StringContent content = new StringContent(jsonContent);

            InstagramMedia result = await ApiCaller.Call<InstagramMedia>(method, apiUri, endpoint, content);
            return result;
        }

        public async Task<List<InstagramMedia>> GetMyMedia(string accessToken)
        {
            return await GetUserMedia("me", accessToken);
        }

        public async Task<List<InstagramMedia>> GetUserMedia(string userId, string accessToken)
        {
            ApiCaller.Method method = ApiCaller.Method.GET;
            string apiUri = "";
            string endpoint = "/" + userId + "/media";

            object requestParams = new
            {
                accessToken
            };
            string jsonContent = JsonConvert.SerializeObject(requestParams);
            StringContent content = new StringContent(jsonContent);

            DataWrapper<InstagramMedia> wrapper = await ApiCaller.Call<DataWrapper<InstagramMedia>>(method, apiUri, endpoint, content);
            return wrapper.data;
        }
    }
}
