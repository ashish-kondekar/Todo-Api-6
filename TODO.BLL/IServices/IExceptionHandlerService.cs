using TODO.BLL.Models.Request;

namespace TODO.BLL.IServices
{
    public interface IExceptionHandlerService
    {
        Task LogException(TodoException exception);
    }
}
