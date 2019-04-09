using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Meli.Models
{
    public class MeliQuestion
    {
        public string id { get; set; }
        public From from { get; set; }
        public string date_created { get; set; }
        public string deleted_from_listing { get; set; }
        public string hold { get; set; }
        public string item_id { get; set; }
        public string seller_id { get; set; }
        public string status { get; set; }
        public string text { get; set; }
        public Answer answer { get; set; }
        public MeliUser user { get; set; }
        public MeliProduct product { get; set; }

        public class From
        {
            public string id { get; set; }
            public string answered_questions { get; set; }
        }

        public class Answer
        {
            public string text { get; set; }
            public string status { get; set; }
            public string date_created { get; set; }
        }
    }
}
