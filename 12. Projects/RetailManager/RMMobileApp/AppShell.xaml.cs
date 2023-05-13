using RMMobileApp.Views;

namespace RMMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProductsView), typeof(ProductsView));
            Routing.RegisterRoute(nameof(ProductDetailView), typeof(ProductDetailView));
        }
    }
}