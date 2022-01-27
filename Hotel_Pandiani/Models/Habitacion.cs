using Hotel_Pandiani.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Pandiani.Models
{
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }

        public Empleado EmpleadoAcargo { get; set; }

        public int IdEmpleado { get; set; }
        

        [Required(ErrorMessage = ErrorMsg.Requerido)]
        [Range(1, 50, ErrorMessage = ErrorMsg.Rango)]
        public int Numero { get; set; }
        
        public bool Mantenimiento { get; set; }

        public bool Estado { get; set; }

        [Display (Name="Fecha de Ingreso")]
        public DateTime Entrada { get; set; }


        [Display(Name = "Fecha de Salida")]
        public DateTime  Salida { get; set; }

        //Enums
        public TipoMantenimiento TipoMantenimiento { get; set; }
        public EstadoDeUsos Ocupacion { get; set; }
        
    }
}
