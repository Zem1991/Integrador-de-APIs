using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.APIs.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli
{
    public class MeliAnswerAAO
    {
        public async Task<MeliQuestion> Post(Dictionary<string, string> callBody, string accessToken)
        {
            return await Post(
                callBody.GetValueOrDefault("questionId"), 
                callBody.GetValueOrDefault("answer"), 
                accessToken);
        }

        public async Task<MeliQuestion> Post(string questionId, string answer, string accessToken)
        {
            object newBody = new
            {
                question_id = questionId,
                text = answer
            };
            return await AnswerQuestion(newBody, accessToken);
        }

        private async Task<MeliQuestion> AnswerQuestion(object callBody, string accessToken)
        {
            MeliApiCaller.Method method = MeliApiCaller.Method.POST;
            string endpoint = "/answers";
            HttpParamsUtility.HttpParams callParams = new HttpParamsUtility.HttpParams()
                .Add("access_token", accessToken);

            MeliQuestion result = await MeliApiCaller.Call<MeliQuestion>(method, endpoint, callParams, callBody);
            return result;
        }
    }
}
