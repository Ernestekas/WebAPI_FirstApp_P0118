using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Entity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }
    }
}
