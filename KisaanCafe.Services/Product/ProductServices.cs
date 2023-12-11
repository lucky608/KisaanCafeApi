using AutoMapper;
using KisaanCafe.Models;
using KisaanCafe.Repository.Product;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace KisaanCafe.Services.Product
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        //private readonly IMapperClient _mapper;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
          //  _mapper = mapper.ThrowIfNull(nameof(mapper));
        }

        public async Task<List<ProductDetails>> GetProductDetailsAsync()
        {
            var products = await _productRepository.GetAllProductAsync().ConfigureAwait(false);
            return products;
        }

       public async Task<PostActionModel> AddProductAsync(ProductCommand product)
        {
            //var newProduct = await _mapper.MapAsync<ProductCommand, ProductCommand>(product).ConfigureAwait(false);
            var newProductData = await _productRepository.AddProductAsync(product).ConfigureAwait(false);


            //if (newProduct != null)
            //{
            //    return newProduct;
            //}

            // Handle the case when products is null
            // You might want to return an empty list or handle it differently based on your requirements
            return new PostActionModel { NewProductDetails = newProductData };
        }
    }
}
