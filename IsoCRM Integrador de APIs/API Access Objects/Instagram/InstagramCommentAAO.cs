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
    public class InstagramCommentAAO
    {
        //public async Task<InstagramComment> GetComment(string comment_id, string accessToken)
        //{
        //    ApiCaller.Method method = ApiCaller.Method.GET;
        //    string apiUri = "";
        //    string endpoint = "/" + comment_id;

        //    object requestParams = new
        //    {
        //        accessToken
        //    };
        //    string jsonContent = JsonConvert.SerializeObject(requestParams);
        //    StringContent content = new StringContent(jsonContent);

        //    InstagramComment result = await ApiCaller.Call<InstagramComment>(method, apiUri, endpoint, content);
        //    return result;
        //}

        public async Task<List<InstagramComment>> GetMediaComments(string mediaId, string accessToken)
        {
            ApiCaller.Method method = ApiCaller.Method.GET;
            string apiUri = "";
            string endpoint = "/" + mediaId + "/comment";

            object requestParams = new
            {
                accessToken
            };
            string jsonContent = JsonConvert.SerializeObject(requestParams);
            StringContent content = new StringContent(jsonContent);

            DataWrapper<InstagramComment> wrapper = await ApiCaller.Call<DataWrapper<InstagramComment>>(method, apiUri, endpoint, content);
            return wrapper.data;
        }

        public async Task<List<InstagramComment>> GetMyReceivedComments(string accessToken)
        {
            return await GetUserReceivedComments("me", accessToken);
        }

        public async Task<List<InstagramComment>> GetUserReceivedComments(string userId, string accessToken)
        {
            InstagramMediaAAO mediaAAO = new InstagramMediaAAO();
            List<InstagramMedia> mediaList = await mediaAAO.GetUserMedia(userId, accessToken);

            List<InstagramComment> result = new List<InstagramComment>();
            foreach (InstagramMedia item in mediaList)
            {
                List<InstagramComment> comments = await GetMediaComments(accessToken, item.id);
                result.AddRange(comments);
            }
            return result;
        }
    }
}
