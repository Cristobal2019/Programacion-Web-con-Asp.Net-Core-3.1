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
                _context.Prestamo.Add(prestamo);
                _context.SaveChanges();
                _notify.Success("Prestamo Nuevo <br/>#" + prestamo.Id);
                return RedirectToAction(nameof(Index));
            }
            _notify.Error("Error en Crear Prestamo");
            return View(prestamo);
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
        ////                            Detalle DE  recibos  X Prestamos
        //****************************************************************************************
        public IActionResult ObtenerReciboxPrestamos(int Id)
        {

            string Descripcion = "No tiene Recibos";

            Recibo MisRecibos = _context.Recibo.Where(a => a.PrestamoId == Id).FirstOrDefault();

            if (MisRecibos != null)
            {
                Descripcion = MisRecibos.Descripcion;

            }
            return Json(new { success = true, message = Descripcion });

        }

        // *************************************************************************************
        ////                         OBTENER EL CLIENTE
        //****************************************************************************************
        public IActionResult ObtenerCliente(int ClienteId)
        {

          
            Customer cliente = _context.Customer.Where(a => a.Id == ClienteId).FirstOrDefault();

            if (cliente != null)
            {               
                return Json(new { success = true,
                    messageNombre = cliente.Nombre,
                    messageDireccion = cliente.Direccion,
                    messageTelefono = cliente.Telefono,
                    messageEmail = cliente.Email
                });
            }
            else
            {
                return Json(new { success = true,
                    messageNombre = "No hay cliente registrado",
                    messageDireccion = "",
                    messageTelefono =0,
                    messageEmail = ""                
                });
            }
           

        }


    }
}
