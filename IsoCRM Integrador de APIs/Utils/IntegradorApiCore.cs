using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Utils
{
    public enum Origin
    {
        Unknown,
        Instagram_Comment,
        MercadoLivre_Message,
        MercadoLivre_Question,
        WhatsApp_Chat
    }

    static class OriginMethods
    {
        public static Origin FromString(string s)
        {
            foreach (Origin origin in Enum.GetValues(typeof(Origin)))
            {
                if (s.Equals(origin.ToString()))
                    return origin;
            }
            return Origin.Unknown;
        }
    }
}
