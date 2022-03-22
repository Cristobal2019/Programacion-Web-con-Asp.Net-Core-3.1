using System.ComponentModel.DataAnnotations;

namespace CristobalCruz.Models
{
    public class Customer
    {
        [Key]
       public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [Display(Name = "Teléfono")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]      
        [StringLength(11, ErrorMessage = "La longitud  permitido es ( {2} a {1}) digitos.", MinimumLength = 8)]     
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        public  string Email { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Fecha { get; set; }
    }
}
