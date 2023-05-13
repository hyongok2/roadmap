namespace RMMobileApp.Models;

public partial class ProductDisplayModel : ObservableValidator
{   
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal RetailPrice { get; set; }

    public bool IsTaxable { get; set; }
    public string ProductImage { get; set; }

    [ObservableProperty]
    int quantityInStock;

    [ObservableProperty]
    [CustomValidation(typeof(ProductDisplayModel), nameof(SelectedQuantityValidation))]
    int selectedQuantity = 0;

    // 아래 정상 동작하지 않는 것 같은데, 나중에 다시 체크해 보자.
    public static ValidationResult SelectedQuantityValidation(int value, ValidationContext context)
    {
        var instance = (ProductDisplayModel)context.ObjectInstance;
        bool isValid = instance.QuantityInStock > value; 

        if (isValid)
        {
            return ValidationResult.Success;
        }

        return new("The value must be less than stock");
    }


    partial void OnSelectedQuantityChanged(int value)
    {
        if (value >= QuantityInStock)
            SelectedQuantity = QuantityInStock;
    }

}
