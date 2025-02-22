﻿using KisaanCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Repository.Product
{
    public interface IProductRepository
    {
        Task<List<ProductDetails>> GetAllProductAsync();
        Task<ProductCommand> AddProductAsync(ProductCommand product);
        Task<bool> DeleteProductAsync(int productId);
        Task<bool> UpdateProductAsync(int productId,ProductCommand product);

    }
}
