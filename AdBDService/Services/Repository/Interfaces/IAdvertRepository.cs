using AdDBService.Services.Helpers;
using Microsoft.AspNetCore.Http;

namespace AdDBService.Services.Repository.Interfaces
{
    public interface IAdvertRepository<Advert>
    {
        Advert GetByGuid(Guid id);
        List<Advert> GetAdvertsListByParams(string propertyName, bool isASC = true, int pagenumber = 1, int onPageCount = DisplayConst.MaxLenghtAdvertsListOnPage);        
        List<Advert> GetList();
        byte[] GetPictureForAdvertByPath(string pathToPicture, int width, int height);

        Task<Guid> Add(Advert entity, IFormFile? uploadedFile = null);
        bool Edit(Advert entity);
        bool Delete(Guid id);
    }
}