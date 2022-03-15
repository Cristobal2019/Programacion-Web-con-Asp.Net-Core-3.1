using CristobalCruz.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CristobalCruz.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class PrestamosController : Controller
    {

        private readonly MyConexionBD _context;
        public PrestamosController( MyConexionBD context)
        {           
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Prestamo.ToList());
        }
    }
}
