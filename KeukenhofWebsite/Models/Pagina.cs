using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class Pagina
    {
        [Key]public int PaginaId { get; set; }
        [Required]public string Titel { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
