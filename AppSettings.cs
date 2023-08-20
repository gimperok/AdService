namespace AdService
{
    public static class AppSettings
    {
        readonly static IConfiguration configuration;

        static AppSettings()
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
        }

        public static string ConnectionString
        {
            get
            {
                var settingsConnectionString = configuration.GetConnectionString("DefaultConnection");
                return settingsConnectionString;
            }
        }

        public static T GetValueInApiSettingSection<T>(string key)
            => configuration.GetSection("ApiSetting").GetValue<T>(key);

            public static int GetUserAdvertCount
            => GetValueInApiSettingSection<int>("UserAdvertCount");
    }
}
