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

        public async Task<PutActionResult> UpdateProductAsync(int productId, ProductCommand productDetails)
        {
            //var updateAccount = await _mapper.MapAsync<Manager.Models.AccountManagement.Account, InfraModels.AccountManagement.Account>(acManagerModel).ConfigureAwait(false);
            bool response = await _productRepository.UpdateProductAsync(productId, productDetails).ConfigureAwait(false);
            if (response)
            {
                return new PutActionResult
                {
                    Result = PutActionResultCode.ResourceUpdatedSuccessfully,
                    NewResourceRelativeUrl = $"/domain/{response}"
                };
            }
            return new PutActionResult { Result = PutActionResultCode.ResourceFailedToUpdate };
        }
        public async Task<DeleteActionCode> DeleteProductAsync(int productId)
        {
            var resultCode = await _productRepository.DeleteProductAsync(productId).ConfigureAwait(false);
            if (resultCode)
            {
                return await Task.FromResult(DeleteActionCode.ResourceDeletedSuccessfully).ConfigureAwait(false);
            }
            return await Task.FromResult(DeleteActionCode.ResourceNotFound).ConfigureAwait(false);
        }
    }
}
