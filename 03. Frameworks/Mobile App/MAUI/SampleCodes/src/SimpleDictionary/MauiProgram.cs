using Plugin.Maui.Audio;
using SimpleDictionary.Pages;
using SimpleDictionary.Services;
using SimpleDictionary.ViewModels;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace SimpleDictionary
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FontAwesomeBrand");
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesomeRegular");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesomeSolid");
                });
            builder.Services.AddSingleton<MainViewModel>(); 
            builder.Services.AddSingleton<ShellViewModel>(); 
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ContentPresenterPage>();
            builder.Services.AddSingleton<IDictionaryService,DictionaryService>();

            builder.Services.AddSingleton(AudioManager.Current);

            return builder.Build();
        }
    }
}