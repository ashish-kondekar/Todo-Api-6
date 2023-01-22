using TODO.BLL.IRepositories;
using TODO.Domain.Entities;

namespace TODO.DAL.Repositories
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        private readonly TodoDbContext _todoDbContext;

        public TodoRepository(TodoDbContext todoDbContext) : base(todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
    }
}
