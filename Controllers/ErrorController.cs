using Microsoft.AspNetCore.Mvc;

namespace ProjectASP.NET.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return Content("What have you done? :(");
        }
    }
}
