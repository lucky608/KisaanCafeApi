using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KisaanCafe.Repository
{
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager,
            ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                // Apply pending migrations during initialization
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                }

                // Seed roles and other initial data as needed
                SeedRoles();
            }
            catch (Exception ex)
            {
                // Handle exceptions during initialization
                throw new Exception("Database initialization failed.", ex);
            }
        }

        private void SeedRoles()
        {
            // Check if the "Manager" role exists, and create it if not
            if (!_roleManager.RoleExistsAsync("Manager").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Manager"
                };

                IdentityResult roleResult = _roleManager.
                    CreateAsync(role).Result;
            }
        }
    }
}
