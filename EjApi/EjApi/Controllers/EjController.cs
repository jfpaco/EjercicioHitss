using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjController : ControllerBase
    {
        private readonly ClienteService _cliente = null;

        public EjController()
        {
            _cliente = new ClienteService();
        }
        // GET: api/<EjController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cliente.obtener());
        }

        // GET api/<EjController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_cliente.obtener(id));
        }

    }
}
