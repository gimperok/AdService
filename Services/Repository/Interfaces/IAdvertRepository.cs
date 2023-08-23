namespace AdService.Services.Repository.Interfaces
{
    public interface IAdvertRepository<Advert>
    {
        Advert GetByGuid(Guid id);
        List<Advert> GetList();

        Task<Guid> Add(Advert entity, IFormFile? uploadedFile = null);
        bool Edit(Advert entity);
        bool Delete(Guid id);
    }
}