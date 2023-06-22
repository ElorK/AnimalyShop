using Microsoft.Build.Framework;
using System.ComponentModel;


namespace ProjectASP.NET.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
        [DisplayName("Comment")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please do not enter a blank comment")]
        public string? CommentText { get; set; }
    }
}
