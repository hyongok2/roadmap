namespace RMMobileApp.ViewModels;

public partial class ProductsViewModel : BaseViewModel
{
    private readonly IMediator _mediator;

    public ObservableCollection<ProductDisplayModel> Products { get; } = new();

	public ProductsViewModel(IMediator mediator)
	{
        Title = "Product List";
        _mediator = mediator;
    }

    [RelayCommand]
    async Task GetProductsList()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            if (Products.Count != 0)
            {
                return; //TO DO : 이 부분은 개선할 필요가 있다. 왜냐면, 로그인 후 갱신이 안되다는 문제 때문에.. 그렇지만, 일단 그냥 진행하고 추후 개선
            }

            var productsDisplay = await _mediator.Send(new GetProductListQuery());

            foreach (var product in productsDisplay)
            {
                Products.Add(product);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error!", $"Unable to get products: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false; 
        }

    }

    [RelayCommand]
    async Task GoToDetail(ProductDisplayModel product)
    {
        if(product is null) return;

        await Shell.Current.GoToAsync(nameof(ProductDetailView), true,
            new Dictionary<string, object>
            {
                {"Product",product }
            });
    }

    [RelayCommand]
    void AddToCart(ProductDisplayModel product)
    {
        if (product is null) return;

        if (product.QuantityInStock <= product.SelectedQuantity)
        {
            product.SelectedQuantity = product.QuantityInStock;
            return;
        }
        product.SelectedQuantity++;
    }

    [RelayCommand]
    void RemoveFromCart(ProductDisplayModel product)
    {
        if (product is null) return;

        if (product.SelectedQuantity <= 0)
        {
            product.SelectedQuantity = 0;
            return;
        }
        product.SelectedQuantity--;
    }

}
