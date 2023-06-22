using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectASP.NET.Models;
using ProjectASP.NET.Repositories;

namespace ProjectASP.NET.Controllers
{
    public class AnimalController : Controller
    {
        private IRepository _repository;
        public AnimalController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(int id)
        {
            if (_repository.GetAnimalById(id) != null)  {
                ViewBag.Comments = _repository.GetComments(id);
            return View(_repository.GetAnimalById(id));
            }
                else
                return Content("Please do not insert invalid id in the url. I'll appreciate it.");
        }
        public IActionResult AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Animal = _repository.GetAnimalById(comment.AnimalId);
                _repository.AddComment(comment);
            }
            return RedirectToAction("Index", "Animal", new { id = comment.AnimalId });
        }
    }
}
