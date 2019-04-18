using Correios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Correios
{
    public class CorreiosPostagemAAO
    {
        public async Task<string[]> GetCodigosPostagem(Dictionary<string, string> callBody)
        {
            string tipoDestinatario = "C";                                              //Identificação com a letra “C”, de cliente
            string identificador = callBody.GetValueOrDefault("identificador");         //CNPJ da empresa, informar somente os números
            long idServico = long.Parse(callBody.GetValueOrDefault("idServico"));       //Id do serviço, porderá ser obtido no método buscaCliente()
            int qtdEtiquetas = int.Parse(callBody.GetValueOrDefault("qtdEtiquetas"));   //Quantidade de etiquetas a serem solicitadas (entre 1 e N)
            string usuario = callBody.GetValueOrDefault("usuario");                     //Fornecido pelo Representante Comercial dos Correios mediante carta de solicitação
            string senha = callBody.GetValueOrDefault("senha");                         //Fornecido pelo Representante Comercial dos Correios mediante carta de solicitação

            CorreiosApi api = new CorreiosApi();
            string apiResult = (await api.solicitaEtiquetasAsync(tipoDestinatario, identificador, idServico, qtdEtiquetas, usuario, senha)).@return;
            string[] result = apiResult.Split(',', qtdEtiquetas);
            return await GeraDigitoVerificadorEtiquetas(result, usuario, senha);
        }

        private async Task<string[]> GeraDigitoVerificadorEtiquetas(string[] etiquetas, string usuario, string senha)
        {
            CorreiosApi api = new CorreiosApi();
            int[] apiResult = (await api.geraDigitoVerificadorEtiquetasAsync(etiquetas, usuario, senha)).@return;

            string[] result = etiquetas;
            for (int i = 0; i < result.Length; i++)
            {
                char ch = Convert.ToChar("" + apiResult[i]);
                char[] str = result[i].ToCharArray();
                str[10] = ch;
                result[i] = new string(str);
            }
            return result;
        }
    }
}
