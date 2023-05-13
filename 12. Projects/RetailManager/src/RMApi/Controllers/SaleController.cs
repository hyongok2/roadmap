using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly ISaleData _saleData;

        public SaleController(ISaleData saleData)
        {
            _saleData = saleData;
        }

        [Authorize(Roles = "Cashier")]
        [HttpPost]
        public void Post(SaleModel sale)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//RequestContext.Principal.Identity.GetUserId();

            _saleData.SaveSale(sale, userId);
        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        [HttpGet]
        public List<SaleReportModel> GetSalesReport()
        {
            //아래와 같은 방법도 있다..
            //if(RequestContext.Principal.IsInRole("Admin"))
            //{

            //}
            //else if (RequestContext.Principal.IsInRole("Manager"))
            //{

            //}

            return _saleData.GetSaleReport();
        }

        [AllowAnonymous]
        [Route("GetTaxRate")]
        [HttpGet]
        public decimal GetTaxRate()
        {
            return _saleData.GetTaxRate();
        }
    }

}
