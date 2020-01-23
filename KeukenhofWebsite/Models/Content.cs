using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class Content
    {
        [Key]public int ContentId { get; set; }
        [Required]public string Titel { get; set; }
        public string Tekst { get; set; }

        public int PaginaId { get; set; }
        public Pagina Pagina { get; set; }
    }


}
