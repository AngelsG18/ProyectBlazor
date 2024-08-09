using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectBlazor.Library
{
    public class AplicacionCLS
    {
        [Required(ErrorMessage = "Ingrese el codigo de la aplicacion")]
        public string Cod_aplicacion { get; set; }

        [Required(ErrorMessage = "Ingrese la descripcion de la aplicacion")]
        public string Des_aplicacion { get; set; }

        [Required(ErrorMessage = "Ingrese la descripcion en inglés de la aplicacion")]
        public string Des_aplicacion_Eng { get; set; }
    }
}
