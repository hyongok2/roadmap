namespace RMMobileApp.ViewModels;

[QueryProperty("Product", "Product")]
public partial class ProductDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    ProductDisplayModel product;

    public ProductDetailViewModel()
    {

    }

    [RelayCommand]
    void AddToCart()
    {
        if (Product is null) return;

        if (Product.QuantityInStock <= Product.SelectedQuantity)
        {
            Product.SelectedQuantity = Product.QuantityInStock;
            return;
        }
        Product.SelectedQuantity++;
    }

    [RelayCommand]
    void RemoveFromCart()
    {
        if (Product is null) return;

        if (Product.SelectedQuantity <= 0)
        {
            Product.SelectedQuantity = 0;
            return;
        }
        Product.SelectedQuantity--;
    }

    [RelayCommand]
    async Task Listen(string word)
    {
        IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();

        SpeechOptions options = new SpeechOptions()
        {
            Pitch = 1.0f,   // 0.0 - 2.0
            Volume = 0.75f, // 0.0 - 1.0
            Locale = locales.FirstOrDefault()
        };

        await TextToSpeech.Default.SpeakAsync(word, options);
    }
}
