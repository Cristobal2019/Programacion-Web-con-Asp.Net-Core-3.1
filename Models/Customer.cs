using System.ComponentModel.DataAnnotations;

namespace CristobalCruz.Models
{
    public class Customer
    {
        [Key]
       public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]       
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        public  string Email { get; set; }
    }
}
