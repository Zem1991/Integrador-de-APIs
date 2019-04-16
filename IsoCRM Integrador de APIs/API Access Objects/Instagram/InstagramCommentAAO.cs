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
            Method method = Method.GET;
            string endpoint = mediaId + "/comments?fields=text,timestamp,user";
            endpoint += "&access_token=" + accessToken;

            FacebookApiCaller caller = new FacebookApiCaller();
            DataWrapper<InstagramComment> wrapper = await caller.Call<DataWrapper<InstagramComment>>(method, endpoint);
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
            foreach (InstagramMedia media in mediaList)
            {
                List<InstagramComment> comments = await GetMediaComments(media.id, accessToken);
                foreach (InstagramComment comment in comments)
                {
                    comment.user.name = comment.user.id;    //TODO: Obter dados dos usuários do Instagram!
                    comment.media = media;
                }
                result.AddRange(comments);
            }
            return result;
        }
    }
}
