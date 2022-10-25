using Microsoft.EntityFrameworkCore;
using ShopProject.Data;
using ShopProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopProject.Repositories
{
    public class MyRepository : IRepository
    {
        private ShopContext context;
      
        public MyRepository(ShopContext _context)
        {
            context = _context;
        }

        public void SaveComment()
        {
            context.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animalInDb = context.AnimalsSet.SingleOrDefault(a => a.AnimalId == id);
            context.AnimalsSet.Remove(animalInDb);
            context.SaveChanges();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return context.AnimalsSet.Include(anm => anm.Comments);
        }

        public Animal GetAnimalById(int id)
        {
            return GetAnimals().Where(an => an.AnimalId == id) as Animal;
        }

        public string GetAnimalCategoty(int id)
        {
            return (context.CategoriesSet.First(cat => cat.CategoryId == id) as Category).CategoryName;
        }

        public void InsertAnimal(Animal animal)
        {
            animal.ImgUrl = "/images/Animals/" + animal.ImgUrl;
            context.AnimalsSet.Add(animal);
            context.SaveChanges();
        }

        public void UpdateAnimal(int id, Animal animal)
        {

            //var animalInDb = context.AnimalsSet.Where(a => a.AnimalId == id).FirstOrDefault();
             //var animalInDb = context.AnimalsSet.SingleOrDefault(a => a.AnimalId == id);
            var animalInDb = context.AnimalsSet!.Single(a => a.AnimalId == id);
            if (animalInDb != null) {
                animalInDb.AnimalName = animal.AnimalName; /*!= null ? animalInDb.AnimalName : default;*/
                animalInDb.Age = animal.Age;
                animalInDb.ImgUrl = "/images/Animals/" + animal.ImgUrl;
                animalInDb.Description = animal.Description;
                animalInDb.CategoryId = animal.CategoryId; }
            
            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.CategoriesSet;
        }


        //public IEnumerable<Animal> GetAnimals()
        //{
        //    return _context.AnimalsSet!;
        //}

        //public void AddAnimal(Animal animal)
        //{
        //    _context.AnimalsSet!.Add(animal);
        //    _context.SaveChanges();
        //}

        //public void DeleteAnimal(int id)
        //{
        //    var animal = _context.AnimalsSet!.Single(m => m.AnimalId == id);
        //    _context.AnimalsSet!.Remove(animal);
        //    _context.SaveChanges();
        //}

        //public void EditAnimal(int id, Animal animal)
        //{
        //    //var personInDb = _context.Candidates!.Single(m => m.PersonId == id);
        //    //personInDb.FirstName = person.FirstName;
        //    //personInDb.LastName = person.LastName;
        //    //_context.SaveChanges();
        //}
    }
    
}
