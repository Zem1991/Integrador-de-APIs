using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Models.Facebook
{
    public class FacebookPage
    {
        public string id { get; set; }
        public string name { get; set; }
        public dynamic picture { get; set; }
        public InstagramBusinessAccount instagram_business_account { get; set; }

        public class InstagramBusinessAccount
        {
            public string id { get; set; }
            public string name { get; set; }
            public string profile_picture_url { get; set; }
        }
    }
}
