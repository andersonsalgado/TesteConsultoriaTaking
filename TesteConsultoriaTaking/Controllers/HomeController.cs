using Microsoft.AspNetCore.Mvc;

namespace TesteConsultoriaTaking.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
