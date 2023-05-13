namespace RMMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FontAwesomeBrand");
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesomeRegular");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesomeSolid");
                });

            using var stream = Assembly.GetExecutingAssembly()
    .       GetManifestResourceStream("RMMobileApp.appsettings.json");
            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);

            SetConfigurationValue(config);
            AddDependencyInjection(builder);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void AddDependencyInjection(MauiAppBuilder builder)
        {
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());//어디에서 가져오느냐에 따라서 다르게 설정한다. 여기서는 해당  Assem 하기에.. 이렇게

            builder.Services.AddTransient<IUserEndPoint, UserEndPoint>();
            builder.Services.AddTransient<IProductEndPoint, ProductEndPoint>();
            builder.Services.AddTransient<ISaleEndPoint, SaleEndPoint>();
            builder.Services.AddSingleton<ILoggedInUserModel, LoggedInUserModel>();

            builder.Services.AddSingleton<IAPIHelper, APIHelper>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<ProductsViewModel>();
            builder.Services.AddTransient<ProductsView>();

            builder.Services.AddTransient<ProductDetailViewModel>();
            builder.Services.AddTransient<ProductDetailView>();

            builder.Services.AddTransient<PlayVideoViewModel>();
            builder.Services.AddTransient<PlayVideoView>();

            builder.Services.AddSingleton<IMapper>(sp => CreateMapper());

        }

        private static void SetConfigurationValue(IConfiguration config)
        {
            MobileConfiguration.ApiUrl = config.GetValue<string>("api");
        }

        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductModel, ProductDisplayModel>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}