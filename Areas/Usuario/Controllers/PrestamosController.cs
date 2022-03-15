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
        public PrestamosController( MyConexionBD context)
        {           
            _context = context;
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
        public IActionResult Create(int ClienteId)
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGuardar(Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Prestamo.Add(prestamo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(prestamo);
        }

        //------------------------------------------------
        //           Editar PRESTAMOS
        //------------------------------------------------
        [HttpGet]
        public IActionResult Edit(int id)
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
        public IActionResult Edit(Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Prestamo.Update(prestamo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
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


    }
}
