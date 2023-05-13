namespace RMDataManager.Library.Models
{
    public class ProductModel
    {
        //Id, ProductName, [Description], RetailPrice, QuantityInstock

        /// <summary>
        /// The unique identifier for a given Product
        /// </summary>
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsTaxable { get; set; }
        public string ProductImage { get; set; }

    }
}
