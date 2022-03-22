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

            Recibo MisRecibos = _context.Recibo.Where(a => a.PrestamoId == Id).FirstOrDefault();
            if (MisRecibos != null)
            {
                return Json(new
                {
                    success = true,  messageDescripcion = MisRecibos.Descripcion,
                    messageMonto = MisRecibos.Monto,  messageCliente = MisRecibos.ClienteId
                });
            }
            else
            {
                return Json(new
                {
                    success = false,  messageDescripcion = "No tiene Recibos",
                    messageMonto = 0,   messageCliente = 0
                });
            }
        }

        // *************************************************************************************
        ////                            Detalle DE  recibos  X Cliente
        //****************************************************************************************
        public IActionResult ObtenerReciboxCustomer(int Id)
        {

            Recibo MisRecibos = _context.Recibo.Where(a => a.ClienteId == Id).FirstOrDefault();
            if (MisRecibos != null)
            {
                return Json(new
                {
                    success = true,
                    messageDescripcion = MisRecibos.Descripcion,
                    messageMonto = MisRecibos.Monto,
                    messagePrestamo = MisRecibos.PrestamoId
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    messageDescripcion = "No tiene Recibos",
                    messageMonto = 0,
                    messagePrestamo = 0
                });
            }
        }

    }   }

