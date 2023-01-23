using System.ComponentModel.DataAnnotations;

namespace TODO.Domain.Models.Request
{
    public class TodoAddRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
