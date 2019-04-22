using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs
{
    public class ApiResponseException : Exception
    {
        public ApiErrorPayload apiErrorPayload { get; set; }

        public ApiResponseException(string apiServiceName, string errorCode, string errorType, string message, List<string> cause)
        {
            apiErrorPayload = new ApiErrorPayload
            {
                apiServiceName = apiServiceName,
                errorCode = errorCode,
                errorType = errorType,
                message = message,
                cause = cause
            };
        }

        public class ApiErrorPayload
        {
            /**
             * O nome da API que originou este erro
             */
            public string apiServiceName { get; set; }
            /**
             * Código do erro - pode ser um código HTTP ou um código definido pela API
             */
            public string errorCode { get; set; }
            /**
             * Tipo de erro gerado, legível por máquinas
             */
            public string errorType { get; set; }
            /**
             * Mensagem do erro gerado, legível por humanos
             */
            public string message { get; set; }
            /**
             * Causas do erro, conforme apontadas pelo serviço utilizado
             */
            public List<string> cause { get; set; }
        }
    }
}
