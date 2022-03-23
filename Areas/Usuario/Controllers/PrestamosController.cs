using AspNetCoreHero.ToastNotification.Abstractions;
using CristobalCruz.Data;
using CristobalCruz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CristobalCruz.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class PrestamosController : Controller
    {

        private readonly MyConexionBD _context;
        private readonly INotyfService _notify;
        public PrestamosController( MyConexionBD context, INotyfService notyf)
        {           
            _context = context;
            _notify = notyf;
        }

        //------------------------------------------------
        //           LISTADO DE PRESTAMOS
        //------------------------------------------------

        public IActionResult Index()
        {
            return View(_context.Prestamo.ToList());
        }

        //------------------------------------------------
        //           CREAR PRESTAMOS
        //------------------------------------------------
        [HttpGet]
        public IActionResult CreatePrestamo(int ClienteId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePrestamo(Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                prestamo.Fecha = System.DateTime.Now;
                _context.Prestamo.Add(prestamo);
                _context.SaveChanges();
                _notify.Success("Prestamo Nuevo <br/>#" + prestamo.Id);
                return RedirectToAction(nameof(Index));
                }
                catch
                {
                    _notify.Error("Error al registrar prestamo");
                    return RedirectToAction("Index", "Home");
                }

            }
            _notify.Warning("Modelo no valido");
            return View();
        }

        //------------------------------------------------
        //           Editar PRESTAMOS
        //------------------------------------------------
        [HttpGet]
        public IActionResult EditPrestamo(int id)
        {
            if (id == 0)
            {        
                return NotFound();
            }
            var prestamo = _context.Prestamo.Find(id);

            if (prestamo == null)
            {            
                return NotFound();
            }
          
            return View(prestamo);          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPrestamo(Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Prestamo.Update(prestamo);
                _context.SaveChanges();
                _notify.Success("Editado Correctamente <br/>Prestamo #" + prestamo.Id);
              
                return RedirectToAction(nameof(Index));
            }
            _notify.Error("Error en Editar Prestamo");
            return View(prestamo);
        }       

        // *************************************************************************************
        ////                            Detalle DE  PRESTAMO X Clientes
        //****************************************************************************************
        public IActionResult ObtenerPrestamoxCliente(int Id)
        {

            string Descripcion = "No tiene Prestamo";

            Prestamo MisPrestamo = _context.Prestamo.Where(a => a.ClienteId == Id).FirstOrDefault();

            if (MisPrestamo != null)
            {
                Descripcion = MisPrestamo.Descripcion;
                return Json(new { success = true, message = Descripcion, messageMonto = MisPrestamo.Monto, messageInteres = MisPrestamo.Interes });
            }
            else
            {
                return Json(new { success = true, message = Descripcion, messageMonto = 0, messageInteres = 0 });
            }

        }


    }
}
