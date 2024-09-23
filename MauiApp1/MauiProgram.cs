
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

            // Zaregistrování Databáze
            builder.Services.AddDbContext<Context>();

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
