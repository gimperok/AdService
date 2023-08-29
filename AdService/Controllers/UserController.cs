using AdJson.Models;
using AdDBService.Services.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseRepository<User> userRepository;

        public UserController(IBaseRepository<User> _repository)
        {
            userRepository = _repository;
        }

        /// <summary>
        /// Получить пользователя по его Guid
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Объект пользователя</returns>
        [HttpGet]
        public User GetUserByGuid(Guid id)
        {
            return userRepository.GetByGuid(id);
        }

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public List<User> GetUsersList()
        {
            return userRepository.GetList();
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user">Обьект пользователя</param>
        [HttpPost]
        public Guid AddUser(User user)
        {
            if (!ModelState.IsValid)
                return Guid.Empty;
            return userRepository.Add(user);
        }

        /// <summary>
        /// Изменить обьект пользователя
        /// </summary>
        /// <param name="user">Обьект пользователя</param>
        [HttpPut]
        public bool EditUser(User user)
        {
            if (!ModelState.IsValid)
                return false;
            return userRepository.Edit(user);
        }

        /// <summary>
        /// Удалить пользователя по его Guid
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        [HttpDelete]
        public bool DeleteUserByGuid(Guid id)
        {
            return userRepository.Delete(id);
        }
    }
}