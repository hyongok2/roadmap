﻿using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public class ProductEndPoint : IProductEndPoint
    {
        private readonly IAPIHelper _apiHelper;

        public ProductEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/Product");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<ProductModel>>();

                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
