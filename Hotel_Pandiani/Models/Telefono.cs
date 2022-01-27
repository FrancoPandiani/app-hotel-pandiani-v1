using Hotel_Pandiani.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Pandiani.Models
{
    public class Telefono
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Empleado")]
        [ForeignKey("Empleado")]
        public int? EmpleadoId { get; set; }

        public Empleado Empleado { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength = 10, ErrorMessage = ErrorMsg.StringMaxMin)]
        public String Numero { get; set; }



    }
}
