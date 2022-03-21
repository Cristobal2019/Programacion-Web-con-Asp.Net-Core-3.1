using AspNetCoreHero.ToastNotification.Abstractions;
using CristobalCruz.Data;
using CristobalCruz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CristobalCruz.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class CustomerController : Controller
    {
        private readonly MyConexionBD _context;
        private readonly INotyfService _notify;
        public CustomerController(MyConexionBD context, INotyfService notyf)
        {
            _context = context;
            _notify = notyf;
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
                _notify.Success("Cliente Registrado <br/>" + customer.Nombre, 10);
                return RedirectToAction("Index","Home");


            }
            _notify.Error("Error en Crear cliente");
            return RedirectToAction("Index", "Home");

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
                return RedirectToAction("Index", "Home");

            }
            _notify.Error("Error en Editar cliente");
            return RedirectToAction("Index", "Home");
        }
        // *************************************************************************************
        ////                                  OBTENER EL CLIENTE
        //****************************************************************************************
        public IActionResult ObtenerCliente(int ClienteId)
        {
            Customer cliente = _context.Customer.Where(a => a.Id == ClienteId).FirstOrDefault();

            if (cliente != null)
            {
                return Json(new
                {
                    success = true,  messageNombre = cliente.Nombre,
                    messageDireccion = cliente.Direccion,  messageTelefono = cliente.Telefono,
                    messageEmail = cliente.Email
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    messageNombre = "No hay cliente registrado",  messageDireccion = "",
                    messageTelefono = 0, messageEmail = ""
                });
            }

        }

    }
}
