using AdDBService.DBContext;
using AdJson.Models;
using AdDBService.Services.Repository.Interfaces;

namespace AdDBService.Services.Repository.Implementations
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationContext db;

        public UserRepository(ApplicationContext _db)
        {
            db = _db;
        }

        
        public User GetByGuid(Guid id)
        {
            User? userFromDb = new();

            if (db == null) return userFromDb;

            try
            {
                userFromDb = db.Users.FirstOrDefault(u => u.Id == id);
                var adsForUser = db.Adverts.Where(ad => ad.UserId == id).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения обьекта {nameof(User)} с Guid: '{id}' из бд.\n" +
                                  $"Место: {nameof(UserRepository)}/{nameof(GetByGuid)} \n" +
                                  $"Error text:{e.Message}");
            }
            return userFromDb ?? new User();
        }


        public List<User> GetList()
        {
            List<User>? allUsersFromDb = new();
            try
            {
                allUsersFromDb = db.Users.ToList();
                var allAdsFromDb = db.Adverts.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения списка User'ов из бд.\n" +
                                  $"Место: {nameof(UserRepository)}/{nameof(GetList)} \n" +
                                  $"Error text:{e.Message}");
            }
            return allUsersFromDb is null ? new() : allUsersFromDb;
        }


        public Guid Add(User entity)
        {
            if (db == null) return Guid.Empty;

            try
            {
                db.Users.Add(entity);
                db.SaveChanges();

                Guid userGuidFromBd = entity.Id;
                return userGuidFromBd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи объекта {nameof(User)} с именем '{entity.Name}' в бд.\n" +
                                  $"Место: {nameof(UserRepository)}/{nameof(Add)} \n" +
                                  $"Error text:{e.Message}");
                return Guid.Empty;
            }
        }


        public bool Edit(User entity)
        {
            if (db == null) return false;

            User? userDb = new();

            try
            {
                userDb = db.Users.FirstOrDefault(p => p.Id == entity.Id);

                if (userDb is null)
                {
                    Console.WriteLine($"Ошибка! " +
                                      $"[Класс {nameof(UserRepository)} / метод {nameof(Edit)}] : " +
                                      $"Объект {nameof(User)} с именем '{entity.Name}' не найден.");
                    return false;
                }

                userDb.Name = entity.Name;
                userDb.IsAdmin = entity.IsAdmin;

                db.Users.Update(userDb);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи объекта {nameof(User)} с именем '{entity.Name}' в бд.\n" +
                                  $"Место: {nameof(UserRepository)}/{nameof(Edit)} \n" +
                                  $"Error text:{e.Message}");
                return false;
            }
        }


        public bool Delete(Guid id)
        {
            if (db == null) return false;

            try
            {
                var user = db.Users.FirstOrDefault(p => p.Id == id);

                if (user == null)
                {
                    Console.WriteLine($"Ошибка! " +
                                      $"[Класс {nameof(UserRepository)} / метод {nameof(Delete)}] : " +
                                      $"Объект {nameof(User)} с Guid: '{id}' не найден.");
                    return false;
                }

                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка удаления обьекта {nameof(User)} с Guid: '{id}' из бд.\n" +
                                  $"Место: {nameof(UserRepository)}/{nameof(Delete)} \n" +
                                  $"Error text:{e.Message}");
                return false;
            }
        }
    }
}