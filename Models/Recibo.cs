using System.ComponentModel.DataAnnotations;

namespace CristobalCruz.Models
{
    public class Recibo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descripción es obligatorio")]
        public string Descripcion { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage = "Monto es obligatorio")]
        public int? Monto { get; set; }
        public int PrestamoId { get; set; }
        public int ClienteId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Fecha { get; set; }

    }
}
