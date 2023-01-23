using Microsoft.Extensions.Logging;
using TODO.BLL.IRepositories;
using TODO.Domain.Entities;

namespace TODO.DAL.Repositories
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly ILogger<Todo> _logger;

        public TodoRepository(TodoDbContext todoDbContext, ILogger<Todo> logger) : base(todoDbContext, logger)
        {
            _todoDbContext = todoDbContext;
            _logger = logger;
        }
    }
}
