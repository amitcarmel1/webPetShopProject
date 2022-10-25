using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Repositories;
using ShopProject.Models;


namespace ShopProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository repository;
        public AdminController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult AdminPage(int id = 1)
        {
            ViewBag.CurrentCategory = repository.GetAnimalCategoty(id);
            ViewBag.Categories = repository.GetCategories();
            return View(repository.GetAnimals().Where(anm => anm.CategoryId == id));
        }

        [HttpPost]
        public IActionResult AdminPageSelect(int id = 1)
        {
            return RedirectToAction("AdminPage", new { id = id });
        }

        public IActionResult DeleteAnimal(int id)
        {
            repository.DeleteAnimal(id);
            return RedirectToAction("AdminPage");
        }

        [HttpGet]
        public IActionResult EditAnimal(int id)
        {
            var currentAnimal = repository.GetAnimals().First(an => an.AnimalId == id);
            return View(currentAnimal);
        }

        [HttpPost]
        public IActionResult EditAnimal(int id, Animal animal)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAnimal(id, animal);
               return RedirectToAction("AdminPage");
            }
            else
            {
                RedirectToAction("AdminPage");
                return EditAnimal(id);
            }

}

        [HttpGet]
        public IActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAnimal(animal);
                return RedirectToAction("AdminPage");
            }
            else
            {
                return View("AddAnimal");
            }

        }
    }
}