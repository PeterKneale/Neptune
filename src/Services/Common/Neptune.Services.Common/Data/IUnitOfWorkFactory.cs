namespace Neptune.Services.Common.Data
{
    public interface IUnitOfWorkFactory<T> where T : IUnitOfWork
    {
        T Begin();
    }
}
