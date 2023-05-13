using AnswerBot.Services;
using AnswerBot.ViewModels;
using AnswerBot.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System.Reflection;

namespace AnswerBot;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
             .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        using var stream = Assembly.GetExecutingAssembly()
								   .GetManifestResourceStream("AnswerBot.appsettings.json");
        var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
        builder.Configuration.AddConfiguration(config);

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<SettingPage>();
        builder.Services.AddSingleton<SettingViewModel>();
        builder.Services.AddTransient<IChatService, ChatGPTService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
