using Green_Light.ViewModels;
using Microsoft.Extensions.Logging;

namespace Green_Light
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("LatoWeb-Regular.ttf", "Lato");
                });

            builder.Services.AddSingleton<DriveConditionsViewModel>();
            builder.Services.AddSingleton<DriveViewModel>();
            builder.Services.AddSingleton<AccountViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
