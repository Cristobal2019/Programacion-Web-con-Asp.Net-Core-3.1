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
    //Cristobalcruzzarate1@
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


    }
}
