using KisaanCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Services.Product
{
    public interface IProductServices
    {
        Task<List<ProductDetails>> GetProductDetailsAsync();
        Task<PostActionModel> AddProductAsync(ProductCommand product);

    }
}
