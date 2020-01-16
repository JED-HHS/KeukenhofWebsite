using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class Park
    {
        [Key] public string Naam { get; set; }
        public DateTime Openingsdag { get; set; }
        public DateTime Sluitingsdag { get; set; }
        public DateTime OpeningstijdenMaandag { get; set; }
        public DateTime OpeningstijdenDinsdag { get; set; }
        public DateTime OpeningstijdenWoensdag { get; set; }
        public DateTime OpeningstijdenDonderdag { get; set; }
        public DateTime OpeningstijdenVrijdag { get; set; }
        public DateTime OpeningstijdenZaterdag { get; set; }
        public DateTime OpeningstijdenZondag { get; set; }
    }
}
