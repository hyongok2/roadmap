using MonkeyFinder.View;

namespace MonkeyFinder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailsPage),typeof(DetailsPage));
        Routing.RegisterRoute(nameof(GridsPage), typeof(GridsPage));
        Routing.RegisterRoute(nameof(MonkeyImagePage), typeof(MonkeyImagePage));
    }
}
