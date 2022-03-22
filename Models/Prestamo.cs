using System.ComponentModel.DataAnnotations;

namespace CristobalCruz.Models
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [Display(Name = "Descripciòn del Prestamo ")]
        public string Descripcion { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage = "Monto es obligatorio")]
        public int? Monto { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage = "Interès es obligatorio")]
        public int? Interes { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage = "Cuota es obligatorio")]
        public int? Cuota { get; set; }
        public int ClienteId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Fecha { get; set; }

    }
}
