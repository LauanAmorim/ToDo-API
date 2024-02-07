using System.ComponentModel.DataAnnotations;

namespace Trendx_toDo.Models
{
    public class Todo
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
