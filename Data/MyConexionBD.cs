using CristobalCruz.Models;
using Microsoft.EntityFrameworkCore;

namespace CristobalCruz.Data
{
    public class MyConexionBD : DbContext
    {
        public MyConexionBD(DbContextOptions<MyConexionBD> options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<Recibo> Recibo { get; set; }
        public DbSet<Customer> Customer { get; set; }

    }
}
