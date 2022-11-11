using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airproject.providers.openair.Models
{
    internal class Response<T>
    {
        public IList<T> results { get; set; }
    }
}
