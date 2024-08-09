using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectBlazor.Library
{
    public class OpcionesCLS
    {
        public string Cod_Opcion { get; set; }
        [Required(ErrorMessage = "Ingrese el Codigo de la Opcion")]
        public string Cod_Aplicacion { get; set; }
        public string Des_Opcion { get; set; }
        public string Des_Opcion_Eng { get; set; }
        public int Nivel { get; set; }
        public string Cod_Padre { get; set; }
        public string tipo { get; set; }

    }
}
