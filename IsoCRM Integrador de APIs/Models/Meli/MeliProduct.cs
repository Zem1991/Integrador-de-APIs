using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Meli.Models
{
    public class MeliProduct
    {
        //Publication data
        public string id { get; set; }
        public string title { get; set; }
        public string category_id { get; set; }
        public string currency_id { get; set; }
        public string price { get; set; }
        public string available_quantity { get; set; }
        public string date_created { get; set; }
        public string end_time { get; set; }
        public string status { get; set; }
        public string permalink { get; set; }

        //Product data
        public string condition { get; set; }

        //Picutres
        public string thumbnail { get; set; }
    }
}
