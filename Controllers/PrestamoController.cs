using CristobalCruz.Data;
using CristobalCruz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CristobalCruz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        // GET: api/<PrestamoController>
        private readonly MyConexionBD _context;
        public PrestamoController( MyConexionBD context)
        {         
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            IEnumerable<Cliente> clientes = _context.Cliente.ToList();
            return clientes;         
        }
    
        // GET api/<PrestamoController>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            Cliente clientes = _context.Cliente.Where(x => x.Id == id).FirstOrDefault();
           
            //Si viene sin datos mostrar null
            if (clientes == null) return new Cliente();

            return clientes;
        }

        // POST api/<PrestamoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrestamoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrestamoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
