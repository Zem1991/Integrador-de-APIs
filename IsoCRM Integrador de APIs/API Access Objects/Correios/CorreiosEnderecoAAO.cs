using Correios;
using Correios.CorreiosServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.API_Access_Objects.Correios
{
    public class CorreiosEnderecoAAO
    {
        public async Task<enderecoERP> Get(string cep)
        {
            CorreiosApi api = new CorreiosApi();
            enderecoERP result = (await api.consultaCEPAsync(cep)).@return;
            return result;
        }
    }
}
