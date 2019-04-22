using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs.Integrador
{
    public class IntegradorNotificationSender
    {
        public string NotificationUri()
        {
            return "https://localhost:4200/notification";
        }

        public void SendNotification(string requestBody = null)
        {
            HttpClient http = new HttpClient();
            StringContent content = (string.IsNullOrEmpty(requestBody) ? null : new StringContent(requestBody));

            Task task = http.PostAsync(NotificationUri(), content);
            task.Start();
        }
    }
}
