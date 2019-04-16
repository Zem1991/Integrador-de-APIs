using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs.Facebook
{
    public class FacebookApiError
    {
        public string code { get; set; }
        public string error_subcode { get; set; }
        public string type { get; set; }
        public string message { get; set; }
    }
}
