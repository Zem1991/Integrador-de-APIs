using IsoCRM_Integrador_de_APIs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Models.Integrador
{
    

    public class IntegradorMensagemPendente
    {
        /**
         * A origem deste item - de onde veio a mensagem recebida?
         */
        public Origin origin { get; set; }
        /**
         * Data/hora da mensagem recebida
         */
        public string datetime { get; set; }
        /**
         * Dados da mensagem que foi recebida
         */
        public EmailEnviadoMensagem message { get; set; }
        /**
         * Dados do usuário que gerou a mensagem
         */
        public EmailEnviadoUsuario user { get; set; }
        /**
         * Dados do objeto onde a mensagem foi gerada
         */
        public EmailEnviadoAux aux { get; set; }

        public class EmailEnviadoMensagem
        {
            /**
		     * Identificador da mensagem recebida
		     */
            public string id { get; set; }
            /**
		     * Texto da mensagem recebida
		     */
            public string message { get; set; }
        }

        public class EmailEnviadoUsuario
        {
            /**
		     * Identificador do usuário que gerou a mensagem
		     */
            public string id { get; set; }
            /**
		     * Nome do usuário que gerou a mensagem
		     */
            public string name { get; set; }
            /**
		     * Url para a página de perfil do usuário
		     */
            public string permalink { get; set; }
            /**
		     * Url para uma imagem representando o usuário
		     */
            public string thumbnail { get; set; }
        }

        public class EmailEnviadoAux
        {
            /**
		     * Identificador do objeto (foto, produto, etc) onde a mensagem foi gerada
		     */
            public string id { get; set; }
            /**
		     * Nome do objeto (foto, produto, etc) onde a mensagem foi gerada
		     */
            public string name { get; set; }
            /**
		     * Url para a página onde o objeto é exibido
		     */
            public string permalink { get; set; }
            /**
		     * Url para uma imagem representando o objeto
		     */
            public string thumbnail { get; set; }
        }
    }
}
