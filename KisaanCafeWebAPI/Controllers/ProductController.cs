using KisaanCafe.Models;
using KisaanCafe.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace KisaanCafeWebAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listFromDb = _context.ProductDetails.ToList().Select(
                x=> new ProductDetails()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Description=x.Description,
                    Prize=x.Prize
                }) ;
            return View(listFromDb);
        }

        [HttpGet]
        [Route("", Name = "Accounts")]
        public async Task<IActionResult> GetAccountsAsync()
        {
            var listFromDb = await _context.ProductDetails
      .Select(x => new ProductDetails
      {
          Id = x.Id,
          Name = x.Name,
          Description = x.Description,
          Prize = x.Prize
      })
      .ToListAsync()
      .ConfigureAwait(false);

            return Ok(listFromDb);
        }
    }
}
