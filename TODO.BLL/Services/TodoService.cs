using TODO.BLL.IRepositories;
using TODO.BLL.IServices;
using TODO.Domain.Entities;

namespace TODO.BLL.Services
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _unitOfWork.TodoRepo.GetAll();
        }

        public async Task<Todo> GetById(int id)
        {
            return await _unitOfWork.TodoRepo.GetOne(d => d.Id == id, d => d.OrderBy(x => x.Id));
        }

        public async Task<int> Add(Todo todo)
        {
            _unitOfWork.TodoRepo.Add(todo);
            await _unitOfWork.CompleteAsync();
            return todo.Id;
        }

        public async Task Update(Todo todo)
        {
            _unitOfWork.TodoRepo.Update(todo);
            await _unitOfWork.CompleteAsync();
        }
    }
}
