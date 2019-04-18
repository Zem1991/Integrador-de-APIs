using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs.Meli
{
    public class MeliNotification
    {
        public string resource { get; set; }
        public string userId { get; set; }
        public string topic { get; set; }
        public string applicationId { get; set; }
        public string attempts { get; set; }
        public string sent { get; set; }
        public string received { get; set; }
    }
}
