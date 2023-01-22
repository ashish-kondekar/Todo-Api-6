using TODO.Domain.Entities;

namespace TODO.BLL.IServices
{
    public interface ITodoService
    {
        public Task<IEnumerable<Todo>> GetAll();
        public Task<Todo> GetById(int id);
        Task<int> Add(Todo todo);
        Task Update(Todo todo);
    }
}
