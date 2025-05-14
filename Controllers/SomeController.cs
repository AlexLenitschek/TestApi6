using Microsoft.AspNetCore.Mvc;

namespace TestApi6.Controllers
{
    public class SomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
