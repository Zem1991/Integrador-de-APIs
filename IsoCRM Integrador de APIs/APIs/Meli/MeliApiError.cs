using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.APIs.Meli
{
    public class MeliApiError
    {
        public string status { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public List<string> cause { get; set; }
    }
}
