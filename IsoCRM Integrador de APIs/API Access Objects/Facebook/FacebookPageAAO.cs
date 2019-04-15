using IsoCRM_Integrador_de_APIs.APIs;
using IsoCRM_Integrador_de_APIs.Models;
using IsoCRM_Integrador_de_APIs.Models.Facebook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Facebook
{
    public class FacebookPageAAO
    {
        public async Task<List<FacebookPage>> GetMyFacebookPages(string accessToken)
        {
            ApiCaller.Method method = ApiCaller.Method.GET;
            string apiUri = "";
            string endpoint = "/me/accounts?fields=name,picture,instagram_business_account.fields(name,profile_picture_url)";

            object requestParams = new
            {
                accessToken
            };
            string jsonContent = JsonConvert.SerializeObject(requestParams);
            StringContent content = new StringContent(jsonContent);

            DataWrapper<FacebookPage> wrapper = await ApiCaller.Call<DataWrapper<FacebookPage>>(method, apiUri, endpoint, content);
            return wrapper.data;
	    }
    }
}
