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

    }
}
