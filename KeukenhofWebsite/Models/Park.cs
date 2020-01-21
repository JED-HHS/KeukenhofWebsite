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
        public DateTime OpeningstijdMaandag { get; set; }
        public DateTime SluitingstijdMaandag { get; set; }
        public DateTime OpeningstijdDinsdag { get; set; }
        public DateTime SluitingstijdDinsdag { get; set; }
        public DateTime OpeningstijdWoensdag { get; set; }
        public DateTime SluitingstijdWoensdag { get; set; }
        public DateTime OpeningstijdDonderdag { get; set; }
        public DateTime SluitingstijdDonderdag { get; set; }
        public DateTime OpeningstijdVrijdag { get; set; }
        public DateTime SluitingstijdVrijdag { get; set; }
        public DateTime OpeningstijdZaterdag { get; set; }
        public DateTime SluitingstijdZaterdag { get; set; }
        public DateTime OpeningstijdZondag { get; set; }
        public DateTime SluitingstijdZondag { get; set; }
    }
}
