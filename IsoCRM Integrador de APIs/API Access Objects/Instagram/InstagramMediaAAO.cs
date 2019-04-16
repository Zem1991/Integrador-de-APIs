using IsoCRM_Integrador_de_APIs.APIs;
using IsoCRM_Integrador_de_APIs.APIs.Facebook;
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
            Method method = Method.GET;
            string endpoint = mediaId + "?fields=caption,timestamp,media_type,media_url,permalink";
            endpoint += "&access_token=" + accessToken;

            FacebookApiCaller caller = new FacebookApiCaller();
            InstagramMedia result = await caller.Call<InstagramMedia>(method, endpoint);
            return result;
        }

        public async Task<List<InstagramMedia>> GetMyMedia(string accessToken)
        {
            return await GetUserMedia("me", accessToken);
        }

        public async Task<List<InstagramMedia>> GetUserMedia(string userId, string accessToken)
        {
            Method method = Method.GET;
            string endpoint = userId + "/media?fields=caption,timestamp,media_type,media_url,permalink";
            endpoint += "&access_token=" + accessToken;

            FacebookApiCaller caller = new FacebookApiCaller();
            DataWrapper<InstagramMedia> wrapper = await caller.Call<DataWrapper<InstagramMedia>>(method, endpoint);
            return wrapper.data;
        }
    }
}
