using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trendx_toDo.ViewModels
{
    public class CreateTaskViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [DefaultValue(false)]
        public bool Completed { get; set; }
    }
}
