using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class Action
    {
        public int Id { get; set; }
        public string PagAction { get; set; }

        public IList<ZoektermAction> ZoektermActions { get; set; }
    }
}
