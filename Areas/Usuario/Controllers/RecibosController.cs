using AspNetCoreHero.ToastNotification.Abstractions;
using CristobalCruz.Data;
using CristobalCruz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CristobalCruz.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class RecibosController : Controller
    {

        private readonly MyConexionBD _context;
        private readonly INotyfService _notify;
        public RecibosController(MyConexionBD context, INotyfService notyf)
        {
            _context = context;
            _notify = notyf;
        }

        //------------------------------------------------
        //           LISTADO DE RECIBOS
        //------------------------------------------------

        public IActionResult Index()
        {
            return View(_context.Recibo.ToList());
        }

        //------------------------------------------------
        //           CREAR PRESTAMOS
        //------------------------------------------------
        [HttpGet]
        public IActionResult CreateRecibo(int PrestamoId, int ClienteId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRecibo(Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                _context.Recibo.Add(recibo);
                _context.SaveChanges();
                _notify.Success("Recibo Nuevo <br/>#" + recibo.Id);
                return RedirectToAction(nameof(Index));
            }
            _notify.Error("Error en Crear Recibo");
            return View(recibo);
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
            public IActionResult ObtenerCliente(int Id)
            {

                string Descripcion = "No hay cliente registrado";

                Customer cliente = _context.Customer.Where(a => a.Id == Id).FirstOrDefault();

                if (cliente != null)
                {
                    Descripcion = cliente.Nombre;

                }
                return Json(new { success = true, message = Descripcion });

            }
        
 }   }

