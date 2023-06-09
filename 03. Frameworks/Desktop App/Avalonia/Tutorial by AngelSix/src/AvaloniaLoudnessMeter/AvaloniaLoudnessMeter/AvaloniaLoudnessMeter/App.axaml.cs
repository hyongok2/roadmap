using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaLoudnessMeter.Sevices;
using AvaloniaLoudnessMeter.ViewModels;
using AvaloniaLoudnessMeter.Views;

namespace AvaloniaLoudnessMeter
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var audioCaptureService = new BassAudioCaptureService();
            var mainViewModel = new MainViewModel(audioCaptureService);
            
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = mainViewModel
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext =mainViewModel
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}