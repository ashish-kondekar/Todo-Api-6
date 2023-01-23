using TODO.Domain.Models.Response;

namespace TODO.Domain.Models.Request
{
    public class TodoException
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public ExceptionType ExceptionType { get; set; }
    }
}