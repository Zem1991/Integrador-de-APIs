using Correios;
using Correios.CorreiosServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Correios
{
    public class CorreiosClienteAAO
    {
        public async Task<clienteERP> Get(Dictionary<string, string> callBody)
        {
            string idContrato = callBody.GetValueOrDefault("idContrato");               //Número do contrato (10 dígitos)
            string idCartaoPostagem = callBody.GetValueOrDefault("idCartaoPostagem");   //Cartão de postagem vinculado ao contrato (10 dígitos)
            string usuario = callBody.GetValueOrDefault("usuario");                     //Fornecido pelo Representante Comercial dos Correios mediante carta de solicitação
            string senha = callBody.GetValueOrDefault("senha");                         //Fornecido pelo Representante Comercial dos Correios mediante carta de solicitação

            CorreiosApi api = new CorreiosApi();
            clienteERP result = (await api.buscaClienteAsync(idContrato, idCartaoPostagem, usuario, senha)).@return;
            return result;
        }
    }
}
