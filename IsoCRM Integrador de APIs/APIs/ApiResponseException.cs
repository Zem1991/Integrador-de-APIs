using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs
{
    public class ApiResponseException : Exception
    {
        public ApiError apiError { get; set; }

        public ApiResponseException(String code, String errorType, String message, List<String> cause)
        {
            apiError = new ApiError();
            apiError.code = code;
            apiError.errorType = errorType;
            apiError.message = message;
            apiError.cause = cause;
        }

        public class ApiError
        {
            /**
             * Código do status de erro
             */
            public String code { get; set; }
            /**
             * Código do tipo de erro gerado, legível por máquinas
             */
            public String errorType { get; set; }
            /**
             * Mensagem do erro gerado, legível por humanos
             */
            public String message { get; set; }
            /**
             * Causas do erro, conforme apontadas pelo serviço utilizado
             */
            public List<String> cause { get; set; }
        }
    }
}
