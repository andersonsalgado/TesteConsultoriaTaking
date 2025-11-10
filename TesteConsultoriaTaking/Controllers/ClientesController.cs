using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TesteConsultoriaTaking.Controllers
{
    [Authorize]
    [Route("clientes")]
    public class ClientesController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("editar/{id}")]
        public IActionResult Edit(Guid id)
        {
            ViewData["ClienteId"] = id;
            return View();
        }

        [HttpGet("detalhes/{id}")]
        public IActionResult Details(Guid id)
        {
            ViewData["ClienteId"] = id;
            return View();
        }

        [HttpGet("remover/{id}")]
        public IActionResult Delete(Guid id)
        {
            ViewData["ClienteId"] = id;
            return View();
        }
    }
}
