using Microsoft.AspNetCore.Mvc;
using ShopProject.Data;
using ShopProject.Repositories;

namespace ShopProject.Controllers
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
            return View(_repository.GetAnimals().OrderByDescending(a => a.Comments.Count).Take(2) );
        }
    }
}
