using Microsoft.EntityFrameworkCore;
using ProjectASP.NET.Models;

namespace ProjectASP.NET.Data
{
    public class AniShopContext : DbContext
    {
        public AniShopContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, ImageSrc = "/images/dogImage.jpeg", Name = "Dog", Age = 5, Description = "A very lovely Maltese dog", CategoryId = 1},
                new { AnimalId = 2, ImageSrc = "/images/catImage.jpeg", Name = "Cat", Age = 11, Description = "This cat will ruin your house furnitures", CategoryId = 1 },
                new { AnimalId = 3, ImageSrc = "/images/cobraImage.jpeg", Name = "Cobra", Age = 4, Description = "Beware, this cobra might devour you complete", CategoryId = 2 },
                new { AnimalId = 4, ImageSrc = "/images/pythonImage.jpeg", Name = "Python", Age = 2, Description = "This is a python. The snake, not the language", CategoryId = 2 }
                );
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Pets" },
                new { CategoryId = 2, Name = "Reptiles" }
                );
            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 1, CommentText = "Cutest dog ever!" },
                new { CommentId = 2, AnimalId = 1, CommentText = "It looks friendly" },
                new { CommentId = 3, AnimalId = 1, CommentText = "Dogs are angels!" },
                new { CommentId = 4, AnimalId = 1, CommentText = "Is it a Maltese?" },
                new { CommentId = 5, AnimalId = 2, CommentText = "Why is it so old?" },
                new { CommentId = 6, AnimalId = 2, CommentText = "I hope it doesn't have any fleas" },
                new { CommentId = 7, AnimalId = 4, CommentText = "Is it venomous?" },
                new { CommentId = 8, AnimalId = 4, CommentText = "So adorable!" },
                new { CommentId = 9, AnimalId = 4, CommentText = "I prefer C#"}
                );
        }
    }
}