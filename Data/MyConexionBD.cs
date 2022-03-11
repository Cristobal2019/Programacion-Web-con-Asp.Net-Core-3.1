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
    
    }
}
