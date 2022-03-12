using System.ComponentModel.DataAnnotations;

namespace CristobalCruz.Models
{
    public class Recibo
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }   
        public int Monto { get; set; }
        public int PrestamoId { get; set; }
        public int ClienteId { get; set; }

    }
}
