namespace AdService.Services.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetByGuid(Guid id);
        List<T> GetList();

        Guid Add(T entity);
        bool Edit(T entity);
        bool Delete(Guid id);
    }
}
