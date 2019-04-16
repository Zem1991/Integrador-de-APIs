using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsoCRM_Integrador_de_APIs.Models
{
    public class DataWrapper<T>
    {
        public List<T> data { get; set; }
    }
}
