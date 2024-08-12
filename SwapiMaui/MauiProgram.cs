using Microsoft.Extensions.Logging;
using SwapiMaui.Service;
using SwapiMaui.View;
using SwapiMaui.ViewModel;

namespace SwapiMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
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
        
        RegisterServices(builder);

        return builder.Build();
    }

    private static void RegisterServices(MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<SwapiService>();
        builder.Services.AddSingleton<ListViewModel>();
        builder.Services.AddSingleton<ListPage>();
    }
}