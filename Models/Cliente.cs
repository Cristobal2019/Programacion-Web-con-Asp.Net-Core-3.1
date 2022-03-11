using System.ComponentModel.DataAnnotations;

namespace CristobalCruz.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
    }
}
