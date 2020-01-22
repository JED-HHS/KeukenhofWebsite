using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class Image
    {
        [Key] public int ImageId { get; set; }
        public string Path { get; set; }
    }
}
