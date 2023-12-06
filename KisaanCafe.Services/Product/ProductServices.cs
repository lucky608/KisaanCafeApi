using KisaanCafe.Models;
using KisaanCafe.Repository.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KisaanCafe.Services.Product
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDetails>> GetProductDetailsAsync()
        {
            var products = await _productRepository.GetAllProductAsync().ConfigureAwait(false);
            return products;
        }
    }
}
