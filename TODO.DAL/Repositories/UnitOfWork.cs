using Microsoft.Extensions.Logging;
using TODO.BLL.IRepositories;
using TODO.Domain.Entities;

namespace TODO.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TodoDbContext _todoDbContext;
        public ITodoRepository TodoRepo { get; private set; }

        public UnitOfWork(TodoDbContext todoDbContext, ILoggerFactory logger)
        {
            _todoDbContext = todoDbContext;
            //_logger = logger.CreateLogger("Todo Logs");

            TodoRepo = new TodoRepository(_todoDbContext);
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
