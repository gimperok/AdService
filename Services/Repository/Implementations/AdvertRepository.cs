﻿using AdService.DBContext;
using AdJson.Models;
using AdService.Services.Repository.Interfaces;
using System.Linq;
using System.IO;

namespace AdService.Services.Repository.Implementations
{
    public class AdvertRepository : IAdvertRepository<Advert>
    {

        private readonly ApplicationContext db;

        public AdvertRepository(ApplicationContext _db)
        {
            db = _db;
        }


        public Advert GetByGuid(Guid id)
        {
            Advert? advertFromDb = new();

            if (db == null) return advertFromDb;

            try
            {
                advertFromDb = db.Adverts.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения обьекта {nameof(Advert)} с Guid: '{id}' из бд.\n" +
                                  $"Место: {nameof(AdvertRepository)}/{nameof(GetByGuid)} \n" +
                                  $"Error text:{e.Message}");
            }
            return advertFromDb ?? new Advert();
        }


        public List<Advert> GetList()
        {
            List<Advert>? allAdvertsFromDb = new();
            try
            {
                allAdvertsFromDb = db.Adverts.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка получения списка Advert'ов из бд.\n" +
                                  $"Место: {nameof(AdvertRepository)}/{nameof(GetList)} \n" +
                                  $"Error text:{e.Message}");
            }
            return allAdvertsFromDb is null ? new() : allAdvertsFromDb;
        }


        public async Task<Guid> Add(Advert entity, IFormFile? uploadedFile = null)
        {
            if (db == null) return Guid.Empty;

            //Такого рода проверку на количество опубликованных пользователем объявлений
            //по-хорошему нужно проводить на клиенте в Web приложении,
            //чтобы исключить лишние запросы к сервису, в случае достижения пользователем
            //установленного для него лимита публикации объявлений;
            if (db.Adverts.Where(adv => adv.UserId == entity.UserId).Count() >= AppSettings.GetMaxUserAdvertCount)
            {
                Console.WriteLine($"Пользователь '{entity.UserId}' " +
                                  $"достиг лимита количества обьявлений ({AppSettings.GetMaxUserAdvertCount}).");
                return Guid.Empty;
            }

            try
            {
                entity.Number = (db.Adverts?.Count() > 0) ? db.Adverts.Max(ad => ad.Number) + 1 : 1;

                if(uploadedFile != null && uploadedFile.Length <= AppSettings.GetMaxAdvertsPhotoWeight)
                {
                    string pathForPicture = $"{AppSettings.GetPathForAdvertsPhoto}{entity.Number}.JPG";

                    using (var fileStream = new FileStream(pathForPicture, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    entity.Picture = pathForPicture;
                }

                db.Adverts.Add(entity);
                db.SaveChanges();

                Guid advertGuidFromBd = entity.Id;
                return advertGuidFromBd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи объекта {nameof(Advert)} с датой создания: '{entity.DateCreate}' в бд.\n" +
                                  $"Место: {nameof(AdvertRepository)}/{nameof(Add)} \n" +
                                  $"Error text:{e.Message}");
                return Guid.Empty;
            }
        }


        public bool Edit(Advert entity)
        {
            if (db == null) return false;

            Advert? advertDb = new();

            try
            {
                advertDb = db.Adverts.FirstOrDefault(p => p.Id == entity.Id);

                if (advertDb is null)
                {
                    Console.WriteLine($"Ошибка! " +
                                      $"[Класс {nameof(AdvertRepository)} / метод {nameof(Edit)}] : " +
                                      $"Объект {nameof(Advert)} с Guid: '{entity.Id}' не найден.");
                    return false;
                }

                advertDb.Number = entity.Number;
                advertDb.Text = entity.Text;
                advertDb.Picture = entity.Picture;
                advertDb.Rate = entity.Rate;
                advertDb.DateCreate = entity.DateCreate;
                advertDb.DateExp = entity.DateExp;
                advertDb.UserId = entity.UserId;

                db.Adverts.Update(advertDb);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи объекта {nameof(Advert)} с Guid: '{entity.Id}' в бд.\n" +
                                  $"Место: {nameof(AdvertRepository)}/{nameof(Edit)} \n" +
                                  $"Error text:{e.Message}");
                return false;
            }
        }


        public bool Delete(Guid id)
        {
            if (db == null) return false;

            try
            {
                var advert = db.Adverts.FirstOrDefault(p => p.Id == id);

                if (advert == null)
                {
                    Console.WriteLine($"Ошибка! " +
                                      $"[Класс {nameof(AdvertRepository)} / метод {nameof(Delete)}] : " +
                                      $"Объект {nameof(Advert)} с Guid: '{id}' не найден.");
                    return false;
                }

                db.Adverts.Remove(advert);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка удаления обьекта {nameof(Advert)} с Guid: '{id}' из бд.\n" +
                                  $"Место: {nameof(AdvertRepository)}/{nameof(Delete)} \n" +
                                  $"Error text:{e.Message}");
                return false;
            }
        }
    }
}