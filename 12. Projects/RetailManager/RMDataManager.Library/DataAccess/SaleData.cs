using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace RMDataManager.Library.DataAccess
{
    public class SaleData : ISaleData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly IProductData _productData;
        private readonly IConfiguration _configuration;

        public SaleData(ISqlDataAccess sqlDataAccess, IProductData productData, IConfiguration configuration)
        {
            _sqlDataAccess = sqlDataAccess;
            _productData = productData;
            _configuration = configuration;
        }


        public decimal GetTaxRate()
        {
            if (decimal.TryParse(_configuration["TaxRate"], out decimal value))
            {
                return value / 100;
            }
            else
            {
                throw new ConfigurationErrorsException("The tax rate is not set up properly");
            }
        }

        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            // TODO: Make This Better...

            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            var taxRate = GetTaxRate();

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                var productInfo = _productData.GetProductById(item.ProductId);

                if (productInfo is null)
                {
                    throw new Exception($"The product Id of {item.ProductId} could not be found in the database.");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            try
            {
                _sqlDataAccess.StartTransaction("RMData");
                _sqlDataAccess.SaveDataInTransaction("dbo.spSale_Insert", sale);
                sale.Id = _sqlDataAccess.LoadDataInTransaction<int, dynamic>(
                                    "dbo.spSale_LookUp",
                                    new { sale.CashierId, sale.SaleDate }).FirstOrDefault();

                foreach (var item in details)
                {
                    item.SaleId = sale.Id;
                    _sqlDataAccess.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
                }

                _sqlDataAccess.CommitTransaction();
            }
            catch
            {
                _sqlDataAccess.RollbackTransaction();
                throw;
            }
        }

        public List<SaleReportModel> GetSaleReport()
        {
            var output = _sqlDataAccess.LoadData<SaleReportModel, dynamic>("dbo.spSale_SaleReport", new { }, "RMdata");

            return output;
        }


    }
}
