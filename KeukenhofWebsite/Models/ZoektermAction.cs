using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class ZoektermAction
    {
        public int ZoektermId { get; set; }
        public Zoekterm Zoekterm { get; set; }

        public int ActionId { get; set; }
        public Action Action { get; set; }
    }
}
