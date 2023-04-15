using Microsoft.AspNetCore.Mvc;

namespace mvcPractica01.Controllers
{
    public class equiposController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
