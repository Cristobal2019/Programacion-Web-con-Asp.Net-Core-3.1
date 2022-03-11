using System.ComponentModel.DataAnnotations;

namespace CristobalCruz.Models
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }   
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public int Interes { get; set; }     
        public int Cuota { get; set; }
        public int ClienteId { get; set; }

    }
}
