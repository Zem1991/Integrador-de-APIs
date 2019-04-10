using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.APIs.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using IsoCRM_Integrador_de_APIs.Models.Integrador;
using IsoCRM_Integrador_de_APIs.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Integrador
{
    public class IntegradorMensagemPendenteAAO
    {
        public async Task<List<IntegradorMensagemPendente>> GetMensagensPendentes(Dictionary<string, string> callBody)
        {
            string mercadoLivreToken = callBody.GetValueOrDefault("mercadoLivreToken");
            //string facebookToken = callBody.GetValueOrDefault("facebookToken");

            List<IntegradorMensagemPendente> result = new List<IntegradorMensagemPendente>();
            List<Task> tasks = new List<Task>();
            if (!string.IsNullOrEmpty(mercadoLivreToken))
            {
                /**
                 * Espera-se que isso possibilite a execução de todas as chamadas para APIs diversas de maneira assíncrona.
                 * Não foi possível testar isso, pois somente um serviço pôde ser utilziado por vez para o desenvolvimento deste projeto.
                 */
                tasks.Add(
                    Task.Run(() =>
                    {
                        result.AddRange(MeliQuestions(mercadoLivreToken).Result);
                    })
                );
            }
            //if (facebookToken != null) {
            // result.AddRange(instagramComments(facebookToken));
            //}
            await Task.WhenAll(tasks);
            return result;
        }

        public async Task<bool> PostAnswer(Dictionary<string, string> callBody)
        {
            string accessToken = callBody.GetValueOrDefault("accessToken");
            Origin origin = OriginMethods.FromString(callBody.GetValueOrDefault("origin"));
            string id = callBody.GetValueOrDefault("id");
            string message = callBody.GetValueOrDefault("message");

            bool result = false;
            switch (origin)
            {
                case Origin.MercadoLivre_Question:
                    MeliAnswerAAO aao = new MeliAnswerAAO();
                    MeliQuestion aaoReturn = await aao.Post(id, message, accessToken);
                    result = aaoReturn != null;
                    break;
            }
            return result;
        }

        private async Task<List<IntegradorMensagemPendente>> MeliQuestions(string accessToken)
        {
            MeliQuestionAAO aao = new MeliQuestionAAO();

            List<IntegradorMensagemPendente> result = new List<IntegradorMensagemPendente>();
            List<MeliQuestion> myReceivedQuestions = await aao.GetMyReceivedQuestions(accessToken);
            foreach (MeliQuestion question in myReceivedQuestions)
            {
                IntegradorMensagemPendente iee = new IntegradorMensagemPendente()
                {
                    origin = Origin.MercadoLivre_Question.ToString(),
                    datetime = DateTime.Now.ToString(),
                    message = new IntegradorMensagemPendente.EmailEnviadoMensagem()
                    {
                        id = question.id,
                        message = question.text
                    },
                    user = question.user == null ? null : new IntegradorMensagemPendente.EmailEnviadoUsuario()
                    {
                        id = question.user.id,
                        name = question.user.nickname,
                        permalink = question.user.permalink,
                        thumbnail = ""  // A imagem de perfil de usuário no MercadoLivre não está salva nos dados de usuário.
                    },
                    aux = question.product == null ? null : new IntegradorMensagemPendente.EmailEnviadoAux()
                    {
                        id = question.product.id,
                        name = question.product.title,
                        permalink = question.product.permalink,
                        thumbnail = question.product.thumbnail
                    }
                };
                result.Add(iee);
            }
            return result;
        }
    }
}
