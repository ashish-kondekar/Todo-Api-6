using System.ComponentModel.DataAnnotations;

namespace TODO.Domain.Models.Request
{
    public class TodoUpdateRequest : TodoAddRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool Done { get; set; }
    }
}
