using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli;
using IsoCRM_Integrador_de_APIs.APIs.Meli;
using IsoCRM_Integrador_de_APIs.Meli.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Meli
{
    public class MeliQuestionAAO
    {
        public async Task<List<MeliQuestion>> GetMyReceivedQuestions(string accessToken)
        {
            MeliUserAAO aao = new MeliUserAAO();
            MeliUser result = await aao.GetMe(accessToken);
            return await GetUserReceivedQuestions(result.id, accessToken);
        }

        public async Task<List<MeliQuestion>> GetUserReceivedQuestions(string userId, string accessToken)
        {
            MeliProductAAO aao = new MeliProductAAO();
            List<MeliProduct> products = await aao.GetUserProducts(userId, accessToken);

		    List<MeliQuestion> result = new List<MeliQuestion>();
		    foreach (MeliProduct product in products) {
			    List<MeliQuestion> questions = await GetProductQuestions(product, accessToken);
                result.AddRange(questions);
		    }
    	    return result;
	    }

        private async Task<List<MeliQuestion>> GetProductQuestions(MeliProduct product, string accessToken)
        {
            MeliApiCaller.Method method = MeliApiCaller.Method.GET;
            string endpoint = "/questions/search";
            HttpParamsUtility.HttpParams callParams = new HttpParamsUtility.HttpParams()
                .Add("item", product.id)
                .Add("access_token", accessToken);

            MeliProductQuestions productQuestions = await MeliApiCaller.Call<MeliProductQuestions>(method, endpoint, callParams);
            MeliUserAAO userAAO = new MeliUserAAO();

            List<MeliQuestion> result = new List<MeliQuestion>();
            foreach (MeliQuestion question in productQuestions.questions)
            {
                question.user = await userAAO.Get(question.from.id, accessToken);
                question.product = product;
                result.Add(question);
            }
            return result;
        }
    }

    public class MeliProductQuestions
    {
        public MeliQuestion[] questions { get; set; }
    }
}
