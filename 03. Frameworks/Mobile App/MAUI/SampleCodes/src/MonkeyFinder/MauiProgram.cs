using MediatR;
using MonkeyFinder.Services;
using MonkeyFinder.View;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System.Reflection;

namespace MonkeyFinder;

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
			});

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IMap>(Map.Default);
		builder.Services.AddMediatR(Assembly.GetExecutingAssembly());//어디에서 가져오느냐에 따라서 다르게 설정한다. 여기서는 해당  Assem 하기에.. 이렇게

        builder.Services.AddSingleton<IMonkeyService, MonkeyService>();
        builder.Services.AddSingleton<MonkeysViewModel>();
        builder.Services.AddTransient<MonkeyDetailsViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<GridsPage>();
        builder.Services.AddTransient<MonkeyImagePage>();


        return builder.Build();
	}
}
