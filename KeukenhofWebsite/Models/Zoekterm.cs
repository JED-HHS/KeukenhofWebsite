using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class Zoekterm
    {
        public int Id { get; set; }
        public string ZoektermString { get; set; }

        public IList<ZoektermAction> ZoektermActions { get; set; }
    }
}
