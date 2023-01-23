using Microsoft.Extensions.Logging;
using TODO.BLL.IRepositories;
using TODO.Domain.Entities;

namespace TODO.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly ILoggerFactory _logger;

        public ITodoRepository TodoRepo { get; private set; }

        public UnitOfWork(TodoDbContext todoDbContext, ILoggerFactory logger)
        {
            _todoDbContext = todoDbContext;
            _logger = logger;

            TodoRepo = new TodoRepository(_todoDbContext, _logger.CreateLogger<Todo>());
        }

        public async Task CompleteAsync()
        {
            await _todoDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _todoDbContext.DisposeAsync();
        }
    }
}
