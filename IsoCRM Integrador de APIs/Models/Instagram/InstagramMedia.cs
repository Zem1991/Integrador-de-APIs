using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Models.Instagram
{
    public class InstagramMedia
    {
        public string id { get; set; }
        public string caption { get; set; }
        public string timestamp { get; set; }
        public string media_type { get; set; }
        public string media_url { get; set; }
        public string permalink { get; set; }
    }
}
