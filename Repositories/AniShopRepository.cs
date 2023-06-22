using ProjectASP.NET.Data;
using ProjectASP.NET.Models;

namespace ProjectASP.NET.Repositories
{
    public class AniShopRepository : IRepository
    {
        private AniShopContext _context;
        public AniShopRepository(AniShopContext context)
        {
            _context = context;
        }
        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals!;
        }
        public Animal GetAnimalById(int id)
        {
            Animal animal = (from Animal a in _context.Animals
                             where a.AnimalId == id
                             select a).FirstOrDefault()!;
            return animal;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories!;
        }
        public Category GetCategoryById(int id)
        {
            Category category = (from Category c in _context.Categories
                             where c.CategoryId == id
                             select c).FirstOrDefault()!;
            return category;
        }
        public IEnumerable<Comment> GetComments(int id)
        {
            IEnumerable<Comment> comments = (from Comment a in _context.Comments
                                             where a.AnimalId == id
                                             select a);
            return comments;
        }
        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
        public void InsertAnimal(Animal animal)
        {
            animal.Category = GetCategoryById(animal.CategoryId);
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }
        public void UpdateAnimal(Animal animal)
        {
            _context.Animals.Update(animal);
            _context.SaveChanges();
        }
        public void DeleteAnimal(int id)
        {
            Animal animal = GetAnimalById(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
        }
    }
}
