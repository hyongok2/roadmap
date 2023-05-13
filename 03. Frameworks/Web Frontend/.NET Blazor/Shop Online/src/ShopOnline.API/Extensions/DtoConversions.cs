using ShopOnline.API.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConverToDto(this IEnumerable<Product> products,
                                                        IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productcategory in productCategories
                    on product.CategoryId equals productcategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productcategory.Name
                    }).ToList();
        }

        public static ProductDto ConverToDto(this Product product,
                                                ProductCategory productCategory)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.Name
            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
                                                            IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Price = product.Price,
                        CartId = cartItem.CartId,
                        Qty = cartItem.Qty,
                        TotalPrice = product.Price * cartItem.Qty
                    }).ToList();
        }

        public static CartItemDto ConvertToDto(this CartItem cartItem,
                                                    Product product)
        {
            return   new CartItemDto
                     {
                         Id = cartItem.Id,
                         ProductId = cartItem.ProductId,
                         ProductName = product.Name,
                         ProductDescription = product.Description,
                         ProductImageURL = product.ImageURL,
                         Price = product.Price,
                         CartId = cartItem.CartId,
                         Qty = cartItem.Qty,
                         TotalPrice = product.Price * cartItem.Qty
                     };
        }

    }
}
