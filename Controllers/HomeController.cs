using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectASP.NET.Models;
using ProjectASP.NET.Repositories;
using static System.Formats.Asn1.AsnWriter;

namespace ProjectASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            IEnumerable<Animal> topAnimals =
                (from Animal in _repository.GetAnimals()
                 orderby Animal.Comments!.Count descending
                 select Animal).Take(2);

            return View(topAnimals);
        }
        [HttpGet]
        public IActionResult Catalogue()
        {
            ViewBag.Categories = _repository.GetCategories();
            return View(_repository.GetAnimals());
        }
        [HttpPost]
        public IActionResult Catalogue(int categoryId)
        {
            if (categoryId != 0)
            {
                ViewBag.Categories = _repository.GetCategories();
                IEnumerable<Animal> filteredAnimals =
                    (from Animal in _repository.GetAnimals()
                     where Animal.CategoryId == categoryId
                     select Animal);
                return View(filteredAnimals);
            }
            else
                return RedirectToAction("Catalogue");
        }
        public IActionResult Admin()
        {
            ViewBag.Categories = _repository.GetCategories();
            ViewBag.AlertState = TempData["AlertState"]?.ToString();
            ViewBag.Alert = TempData["Alert"]?.ToString();
            return View(_repository.GetAnimals());
        }
        [HttpPost]
        public IActionResult Admin(int categoryId)
        {
            if (categoryId != 0)
            {
                ViewBag.Categories = _repository.GetCategories();
                IEnumerable<Animal> filteredAnimals =
                    (from Animal in _repository.GetAnimals()
                     where Animal.CategoryId == categoryId
                     select Animal);
                return View(filteredAnimals);
            }
            else
                return RedirectToAction("Admin");
        }
    }
}
