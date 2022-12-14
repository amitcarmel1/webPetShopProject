using ShopProject.Models;

namespace ShopProject.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimalById(int id);
        void InsertAnimal(Animal animal);
        void SaveComment();
        void UpdateAnimal(int id, Animal animal);
        void DeleteAnimal(int id);
        string GetAnimalCategoty(int categoryId);
        IEnumerable<Category> GetCategories();
        
    }
}
