using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class QenA
    {
        [Key] public int AnswerId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
