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
    public class HomeController2 : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyConexionBD _context;
        //public HomeController2(ILogger<HomeController2> logger2, MyConexionBD context)
        //{
        //    _logger = logger2;
        //    _context = context;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            return View( _context.Customer.ToList());
        }
        [HttpGet]
        public IActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCliente( Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]
        public IActionResult EditCliente(int? id)
        {
            if (id==null)
            { return NotFound(); }
            var cliente = _context.Customer.Find(id);
           
            if(cliente == null)
            {  return NotFound(); }
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
                return RedirectToAction(nameof(Index));

            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult DetalleCliente(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var cliente = _context.Customer.Find(id);

            if (cliente == null)
            { return NotFound(); }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult DeleteCliente(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var cliente = _context.Customer.Find(id);

            if (cliente == null)
            { return NotFound(); }
            return View(cliente);
        }

        [HttpPost, ActionName("DeleteCliente")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClientePost(int? id)
        {
            var usuario = await _context.Customer.FindAsync(id);
            if(usuario==null)
            {
                return View();
            }            
                _context.Customer.Remove(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }
        // *************************************************************************************
        ////                            Detalle DE  Cliente
        //****************************************************************************************
        public IActionResult ObtenerDetalleCliente(int Id)
        {      

            string Direccion = "No tiene descripcion";
         
            Cliente cliente = _context.Cliente.Where(a => a.Id == Id).FirstOrDefault();

            if (cliente != null && !string.IsNullOrEmpty(cliente.Direccion))
            {
                Direccion = cliente.Direccion;              
            }
            return Json(new { success = true, message = Direccion });      

        }

        // *************************************************************************************
        ////                            LISTADO DE  Cliente
        //****************************************************************************************
        public IActionResult ClientesListado()
        {
            List<Cliente> clientes = _context.Cliente.ToList();

            return View(clientes);
        }

        // *************************************************************************************
        ////                               Crear nuevo Cliente
        //****************************************************************************************
        public IActionResult ClienteNuevo()
        {
            return View();
        }
        public IActionResult ClienteNuevoGuardar(Cliente cliente)
        {

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                return Json(new { success = false, message = "Favor llenar los datos"  });
            }
            else
            {
                _context.Cliente.Add(cliente);
                _context.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = "Cliente Registrado"
                });
            }

        }


        // *************************************************************************************
        ////                               Crear Prestamo
        //****************************************************************************************
        public IActionResult PrestamoNuevo(int id)
        {
            Cliente modelp = _context.Cliente.Where(h => h.Id == id).FirstOrDefault();
            return PartialView("PrestamoNuevo", modelp);
        }
        public IActionResult PrestamoNuevoGuardar(Prestamo Prestamo)
        {

            _context.Prestamo.Add(Prestamo);
            _context.SaveChanges();
            return Json(new
            {
                success = true,
                message = "Guardado satisfactoriamente Prestamo #" + Prestamo.Id
            });
           
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
