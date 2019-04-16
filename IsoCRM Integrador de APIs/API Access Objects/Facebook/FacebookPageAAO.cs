using IsoCRM_Integrador_de_APIs.APIs;
using IsoCRM_Integrador_de_APIs.APIs.Facebook;
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
            Method method = Method.GET;
            string endpoint = "me/accounts?fields=name,picture,instagram_business_account.fields(name,profile_picture_url)";
            endpoint += "&access_token=" + accessToken;

            FacebookApiCaller caller = new FacebookApiCaller();
            DataWrapper<FacebookPage> wrapper = await caller.Call<DataWrapper<FacebookPage>>(method, endpoint);
            return wrapper.data;
	    }
    }
}
