using IsoCRM_Integrador_de_APIs.APIs.Integrador;
using IsoCRM_Integrador_de_APIs.APIs.Meli;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Integrador
{
    public class IntegradorNotificationAAO
    {
        public async Task<bool> Notify(MeliNotification meli)
        {
            IntegradorNotification notification = new IntegradorNotification
            {
                apiServiceName = "MercadoLivre",
                apiAppId = meli.applicationId,
                apiUserId = meli.userId,
                apiObject = meli.topic,
                apiEndpoint = meli.resource,
                attempts = meli.attempts,
                datetimeSent = meli.sent,
                datetimeReceived = meli.received,
            };
            string requestBody = JsonConvert.SerializeObject(notification);

            IntegradorNotificationSender ins = new IntegradorNotificationSender();
            ins.SendNotification(requestBody);
            return await Task.FromResult(true);
        }
    }
}
