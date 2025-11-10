using Microsoft.AspNetCore.Mvc;

namespace TesteConsultoriaTaking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
