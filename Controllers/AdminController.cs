using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET.Models;
using ProjectASP.NET.Repositories;

namespace ProjectASP.NET.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _repository;
        public AdminController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Delete(int id)
        {
            if (_repository.GetAnimalById(id) != null)
            {
                _repository.DeleteAnimal(id);
                return RedirectToAction("Admin", "Home");
            }
            else
                return Content("Please do not insert invalid id in the url. I'll appreciate it.");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _repository.GetCategories();
            Animal newAnimal = new Animal();
            return View(newAnimal);
        }
        [HttpPost]
        public IActionResult Add(Animal animal, IFormFile imgFile)
        {
            ViewBag.Categories = _repository.GetCategories();
            if (ModelState.IsValid)
            {
                ImageUpload(animal, imgFile);
                _repository.InsertAnimal(animal);
                TempData["AlertState"] = "alert alert-success show";
                TempData["Alert"] = "Animal added successfuly";
                return RedirectToAction("Admin", "Home");
            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_repository.GetAnimalById(id) != null)
            {
                ViewBag.Categories = _repository.GetCategories();
                Animal animal = _repository.GetAnimalById(id);
                return View(animal);
            }
            else
                return Content("Please do not insert invalid id in the url. I'll appreciate it.");
        }

        [HttpPost]
        public IActionResult Edit(Animal animal, IFormFile imgFile)
        {
            ViewBag.Categories = _repository.GetCategories();
            if (imgFile == null)
            {
                ModelState.Remove("imgFile");
            }
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    ImageUpload(animal, imgFile);
                }
                _repository.UpdateAnimal(animal);
                TempData["AlertState"] = "alert alert-success show";
                TempData["Alert"] = "Animal updated successfuly";
                return RedirectToAction("Admin", "Home");
            }
            else
                return View(animal);
        }

        //Image Uploading Method
        static void ImageUpload(Animal animal, IFormFile imgFile)
        {
            string imgName = imgFile.FileName;
            imgName = Path.GetFileName(imgName);
            if (Path.Combine("/images", imgName) != animal.ImageSrc)
            {
                animal.ImageSrc = Path.Combine("/images", imgName); //Getting the path for the animal object
                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgName);
                using (var stream = new FileStream(uploadpath, FileMode.Create))
                {
                    imgFile.CopyToAsync(stream);
                }
            }
        }
    }
}