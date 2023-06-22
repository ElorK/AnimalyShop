using ProjectASP.NET.Models;

namespace ProjectASP.NET.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimalById(int id);
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        IEnumerable<Comment> GetComments(int id);
        void AddComment(Comment comment);
        void InsertAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);
        
    }
}
