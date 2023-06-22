using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string? ImageSrc { get; set; }
        [Required(ErrorMessage = "Please enter a name for the animal")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name should be between 2 to 25 characters long")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter an age in years")]
        [Range(1, 99, ErrorMessage = "Age should be between 1 and 99")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(400, ErrorMessage = "Description should not be longer than 400 characters")]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}