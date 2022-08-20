using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
