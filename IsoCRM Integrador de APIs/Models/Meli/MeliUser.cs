using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Meli.Models
{
    public class MeliUser
    {
        //	Account data
        public string id { get; set; }
        public string nickname { get; set; }
        public string email { get; set; }
        public string registration_date { get; set; }
        public string permalink { get; set; }

        //	Personal data
        public string first_name { get; set; }
        public string last_Name { get; set; }
    }
}
