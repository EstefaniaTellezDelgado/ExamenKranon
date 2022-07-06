using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Autor
    {
        public int IdAutor { get; set; }
        [Display(Name = "Nombre del Autor")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Fecha de Nacimiento")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FechaNacimiento { get; set; }
        [Display(Name = "Lugar de Nacimiento")]
        public string LugarNacimiento { get; set; }
        public List<object> Autores { get; set; }
        public string NombreCompleto { get; set; }
    }
}
