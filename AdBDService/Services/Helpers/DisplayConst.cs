using System.Reflection.Metadata;

namespace AdDBService.Services.Helpers
{
    public static class DisplayConst
    {   
        /// <summary>
        /// Максимальная длинна списка объявлений выгружаемая по запросу
        /// </summary>
        public const int MaxLenghtAdvertsListOnPage = 10;

        /// <summary>
        /// Количество доступных объявлений для каждого пользователя
        /// </summary>
        public const int MaxUserAdvertCount = 3;

        /// <summary>
        /// Ограничение на загрузку фото для объявления, максимум: 10 Mb
        /// </summary>
        public const int MaxAdvertsPhotoWeight = 1000000;

        /// <summary>
        /// Путь для сохранения фото
        /// </summary>
        public const string PathForAdvertsPhoto = "/Pictures/";
    }
}