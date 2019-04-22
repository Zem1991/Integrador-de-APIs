using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Integrador;
using IsoCRM_Integrador_de_APIs.APIs.Integrador;
using IsoCRM_Integrador_de_APIs.APIs.Meli;
using Newtonsoft.Json;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli
{
    public class MeliNotificationAAO
    {
        public async Task<bool> Notify(Dictionary<string, string> callBody)
        {
            MeliNotification notification = new MeliNotification
            {
                resource = callBody.GetValueOrDefault("resource"),
                userId = callBody.GetValueOrDefault("user_id"),
                topic = callBody.GetValueOrDefault("topic"),
                applicationId = callBody.GetValueOrDefault("application_id"),
                attempts = callBody.GetValueOrDefault("attempts"),
                sent = callBody.GetValueOrDefault("sent"),
                received = callBody.GetValueOrDefault("received")
            };

            IntegradorNotificationAAO integrador = new IntegradorNotificationAAO();
            return await integrador.Notify(notification);
        }
    }
}
