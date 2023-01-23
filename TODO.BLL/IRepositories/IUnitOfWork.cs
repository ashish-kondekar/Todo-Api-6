namespace TODO.BLL.IRepositories
{
    public interface IUnitOfWork
    {
        ITodoRepository TodoRepo { get; }

        Task CompleteAsync();
    }
}
