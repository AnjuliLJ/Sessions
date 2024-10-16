using MauiBlazorHybrid.Services;
using MauiBlazorHybrid.ViewModels;
using MauiBlazorHybrid.Views;
using Microsoft.Extensions.Logging;

namespace MauiBlazorHybrid
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddScoped<HelloPage>();
            builder.Services.AddScoped<HelloViewModel>();

            builder.Services.AddScoped<IHelloService, HelloService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
