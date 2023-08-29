using AdJson.Models;
using AdApi.Services.Helpers;
using AdDBService.Services.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertRepository<Advert> advertRepository;

        public AdvertController(IAdvertRepository<Advert> _repository)
        {
            advertRepository = _repository;
        }

        /// <summary>
        /// Получить объявление по его Guid
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <returns>Объект объявления</returns>
        [HttpGet]
        public Advert GetAdvertByGuid(Guid id)
        {
            return advertRepository.GetByGuid(id);
        }

        /// <summary>
        /// Список объявлений выгружаемый по запросу с учетом входящих параметров
        /// </summary>
        /// <typeparam name="T">Тип свойства для сортировки</typeparam>
        /// <param name="sortParam">Значение свойства для сортировки</param>
        /// <param name="isASC">Тип сортировки прямая/обратная. Если не указан, то прямая</param>
        /// <param name="pagenumber">Номер страницы. Если не указан, то 1</param>
        /// <param name="onPageCount">Количество выгружаемых объявлений. Если не указан то 10</param>
        /// <returns></returns>
        [HttpGet]
        public List<Advert> GetAdvertsListByParams(string propertyName, bool isASC = true, int pagenumber = 1, int onPageCount = DisplayConst.MaxLenghtAdvertsListOnPage)
        {
            return advertRepository.GetAdvertsListByParams(propertyName, isASC, pagenumber, onPageCount);
        }


        /// <summary>
        /// Получить список объявлений
        /// </summary>
        /// <returns>Список объявлений</returns>
        [HttpGet]
        public List<Advert> GetAdvertsList()
        {
            return advertRepository.GetList();
        }


        /// <summary>
        /// Получить изображение объявления зная путь к обложке
        /// </summary>
        /// <param name="pathToPicture">Путь к файлу обложки</param>
        /// <param name="width">Необходимая ширина обложки</param>
        /// <param name="height">Необходимая высота обложки</param>
        /// <returns>Обложка объявления в формате массив байтов</returns>
        [HttpGet]
        public byte[] GetPictureForAdvertByPath(string pathToPicture, int width, int height)
        {
            return advertRepository.GetPictureForAdvertByPath(pathToPicture, width, height);
        }


        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="advert">Обьект объявления</param>
        [HttpPost]
        public async Task<Guid> AddAdvert(Advert advert, IFormFile uploadedFile)
        {
            if (!ModelState.IsValid)
                return Guid.Empty;
            return await advertRepository.Add(advert, uploadedFile);
        }


        /// <summary>
        /// Изменить обьект объявления
        /// </summary>
        /// <param name="advert">Обьект объявления</param>
        [HttpPut]
        public bool EditAdvert(Advert advert)
        {
            if (!ModelState.IsValid)
                return false;
            return advertRepository.Edit(advert);
        }


        /// <summary>
        /// Удалить объявление по его Guid
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        [HttpDelete]
        public bool DeleteAdvertByGuid(Guid id)
        {
            return advertRepository.Delete(id);
        }
    }
}