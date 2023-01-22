using System.ComponentModel.DataAnnotations;

namespace TODO.BLL.Models.Request
{
    public class TodoAddRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
