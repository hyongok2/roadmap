namespace RMMobileApp.Views;

public partial class ProductsView : ContentPage
{
	public ProductsView(ProductsViewModel productsViewModel)
	{
		InitializeComponent();
		BindingContext= productsViewModel;
	}
}