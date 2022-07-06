using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int? IdLibro { get; set; }
        public string Titulo { get; set; }
        [Display(Name = "Año de Publicación")]
        public string AñoPublicacion { get; set; }
        [Display(Name = "Número de Páginas")]
        public string NumeroPaginas { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public List<object> Libros { get; set; }

        public ML.Autor Autor { get; set; }
        public ML.Editorial Editorial { get; set; }
        public ML.Genero Genero { get; set; }
        
    }
}
