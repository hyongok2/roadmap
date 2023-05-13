using System.Reflection;

//아래 방법은 필요없다. MainProgram.cs에서 추가하면 된다.
//[assembly: ExportFont("Font Awesome 6 Free-Solid-900.otf", Alias ="FAS")]
//[assembly: ExportFont("Font Awesome 6 Brands-Regular-400.otf", Alias ="FAB")]
//[assembly: ExportFont("Font Awesome 6 Free-Regular-400.otf", Alias ="FAR")]
namespace SimpleDictionary
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}