using AdJson.Models;
using AdService.Services.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdService.Controllers
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
        /// Получить список объявлений
        /// </summary>
        /// <returns>Список объявлений</returns>
        [HttpGet]
        public List<Advert> GetAdvertsList()
        {
            return advertRepository.GetList();
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