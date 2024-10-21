using MauiApp1.Data;
using MauiApp1.Pages;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            //Registrace stránek do DI kontejneru
            builder.Services.AddScoped<MainPage>();
            builder.Services.AddScoped<AddPersonPage>();
            builder.Services.AddScoped<AddCarPage>();

            // Registrace služeb do DI kontejneru

            // Zaregistrování Databáze
            builder.Services.AddDbContext<Context>();

            // Data Managers
            builder.Services.AddScoped<IDataManager, DataManager>();
            builder.Services.AddScoped<ICarManager, CarManager>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
