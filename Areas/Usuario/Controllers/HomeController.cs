using AspNetCoreHero.ToastNotification.Abstractions;
using CristobalCruz.Data;
using CristobalCruz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CristobalCruz.Controllers
{   // actualizar mi modelo
    //add-migration migration-producto -context MyConexionBD
    //update-database -context MyConexionBD
    //para los roles y permiso
    // update-database -context ApplicationDbContext

    [Area("Usuario")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyConexionBD _context;
        private readonly INotyfService _notify;
        public HomeController(ILogger<HomeController> logger, MyConexionBD context, INotyfService notyf)
        {
            _logger = logger;
            _context = context;
            _notify=notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {         
            return View( _context.Customer.ToList());
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //                CREAR CLIENTE
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public IActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCliente(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();
                _notify.Success("Cliente Registrado <br/>" + customer.Nombre,10);
                return RedirectToAction(nameof(Index));
               

            }
            _notify.Error("Error en Crear cliente");
            return View(); 
           
        }

       
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //                EDITAR CLIENTE
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [HttpGet]
        public IActionResult EditCliente(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var cliente = _context.Customer.Find(id);

            if (cliente == null)
            { return NotFound(); }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCliente(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
                _notify.Success("Cliente Editado <br/>" + customer.Nombre);
                return RedirectToAction(nameof(Index));

            }
            _notify.Error("Error en Editar cliente");
            return View(customer);
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
                
            }
            return Json(new { success = true, message = Descripcion  });

        }

    }
}
