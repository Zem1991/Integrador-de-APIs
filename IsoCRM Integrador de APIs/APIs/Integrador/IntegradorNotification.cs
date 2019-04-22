using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs.Integrador
{
    public class IntegradorNotification
    {
        public string apiServiceName { get; set; }
        public string apiAppId { get; set; }
        public string apiUserId { get; set; }
        public string apiObject { get; set; }
        public string apiEndpoint { get; set; }
        public string attempts { get; set; }
        public string datetimeSent { get; set; }
        public string datetimeReceived { get; set; }

        public IntegradorNotification()
        {

        }
    }
}
