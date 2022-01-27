using Hotel_Pandiani.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Pandiani.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        
        public List<Asistencia> ListaAsistencia { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
        public  List<Telefono> Telefonos { get; set; }

            
        // Propiedades  no navegacionales

        [Required(ErrorMessage = ErrorMsg.Requerido)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = ErrorMsg.StringMaxMin)]
        
        public string Nombre { get; set; }


        [Required(ErrorMessage = ErrorMsg.Requerido)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = ErrorMsg.StringMaxMin)]
        public string Apellido { get; set; }

        public int Antiguedad { get; set; }


        [Required(ErrorMessage = ErrorMsg.Requerido)]
        [DataType(DataType.Currency)]
        [Range(1, 99999999, ErrorMessage = ErrorMsg.Rango)]
        [Display(Name = "Sueldo")]
        public double Sueldo { get; set; }

        [Required]
        [Display(Name = "Ingreso")]
        public DateTime FechaIngreso { get; set; }


        //Enums

        [Display(Name = "Turno")]
        public TurnoEnum TurnoEnum { get; set; }

        [Display(Name = "Cargo")]
        public CargoEnum Cargo { get; set; }


    }
}

