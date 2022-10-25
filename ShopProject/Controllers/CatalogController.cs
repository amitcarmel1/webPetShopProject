using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Data;
using ShopProject.Models;
using ShopProject.Repositories;

namespace ShopProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository repository;
        public CatalogController(IRepository _repository)
        {
            repository = _repository;
        }
       
        public IActionResult CatalogPage(int id )
        {
            ViewBag.CurrentCategory = repository.GetAnimalCategoty(id);
            ViewBag.Categories = repository.GetCategories();
            return View(repository.GetAnimals().Where(anm => anm.CategoryId == id));
           
        }

        [HttpPost]
        public IActionResult CatalogPageSelect(int id = 1)
        {
            return RedirectToAction("CatalogPage", new { id = id });
        }
       
       

        public IActionResult DetailPage(int id)
        {
            var animal = repository.GetAnimals().First(an => an.AnimalId == id);
            DetailViewModel model = new DetailViewModel()
            {
                Animal=animal,
                AnimalCategory=repository.GetAnimalCategoty(animal.CategoryId),
                AnimalComments=animal.Comments
             };
            return View(model);
        }

        [HttpPost]
        public IActionResult DetailPage(int Animal, string CommentMessage)
        {
                var animal = repository.GetAnimals().First(an => an.AnimalId == Animal);
                animal.Comments.Add(new Comment() { CommentMessage = CommentMessage });
                repository.SaveComment();
                return RedirectToAction("CatalogPage");
        }
    }
}