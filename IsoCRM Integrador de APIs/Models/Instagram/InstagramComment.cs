using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Models.Instagram
{
    public class InstagramComment
    {
        public string id { get; set; }
        public string text { get; set; }
        public string timestamp { get; set; }
        public InstagramUser user { get; set; }
        public InstagramMedia media { get; set; }
    }
}
