using System.ComponentModel.DataAnnotations;

namespace Trendx_toDo.ViewModels
{
    public class EditTaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

    }
}
