using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    internal partial class AutorMetadata
    {
        public int IdAutor { get; set; }

        [Display(Name = "Nombre Autor")]
        public string Nombre { get; set; }
        public virtual ICollection<Libro> Libro { get; set; }
    }

}
