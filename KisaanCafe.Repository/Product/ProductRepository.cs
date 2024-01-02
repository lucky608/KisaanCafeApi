using KisaanCafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisaanCafe.Repository.Product
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDetails>> GetAllProductAsync()
        {
            try
            {
                var listFromDb = await _context.ProductDetails
                    .Select(x => new ProductDetails
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Prize = x.Prize,
                        Weight=x.Weight,
                        ImageData = x.ImageData,
                        
                    })
                    .ToListAsync()
                    .ConfigureAwait(false);

                return listFromDb;
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                throw;
            }
        }

        public async Task<ProductCommand> AddProductAsync(ProductCommand product)
        {
            _context.ProductDetails.Add(product);
            try
            {
                var result = await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return product;
        }

        public async Task<bool> UpdateProductAsync(int productId,ProductCommand product)
        {
            _context.ProductDetails.Update(product);
            var response = (await _context.SaveChangesAsync().ConfigureAwait(false)) > 0;
            return response;
        }
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var account = await _context.ProductDetails.FindAsync(productId).ConfigureAwait(false);

            if (account == null)
                return false;

            //Delete the account
            _context.ProductDetails.Remove(account);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

    }
}
