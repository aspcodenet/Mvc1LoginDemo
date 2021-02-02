using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mvc1LoginDemo.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
            SeedRoles(dbContext);

            SeedUsers(userManager);
            //
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            AddUserIfNotExists(userManager, "stefan@superduper.se",
                "Hejsan123#", new[] {"Admin"});

            AddUserIfNotExists(userManager, "kalle@superduper.se",
                "Hejsan123#", new[] { "PlayerAdmin" });

            AddUserIfNotExists(userManager, "lisa@superduper.se",
                "Hejsan123#", new[] { "RefAdmin" });

            AddUserIfNotExists(userManager, "maja@superduper.se",
                "Hejsan123#", new[] { "RefAdmin", "PlayerAdmin" });

        }

        private static void AddUserIfNotExists(UserManager<IdentityUser> userManager,
            string userName, string password, string[] roles)
        {
            if (userManager.FindByEmailAsync(userName).Result != null)
                return;
            var identityUser = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            var result = userManager.CreateAsync(identityUser, password).Result;
            var r = userManager.AddToRolesAsync(identityUser, roles).Result;
        }

        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (role == null)
                dbContext.Roles.Add(new IdentityRole { Name= "Admin", NormalizedName = "Admin" });
            role = dbContext.Roles.FirstOrDefault(r => r.Name == "PlayerAdmin");
            if (role == null)
                dbContext.Roles.Add(new IdentityRole { Name = "PlayerAdmin", NormalizedName = "PlayerAdmin" });
            role = dbContext.Roles.FirstOrDefault(r => r.Name == "RefAdmin");
            if (role == null)
                dbContext.Roles.Add(new IdentityRole { Name = "RefAdmin", NormalizedName = "RefAdmin" });

            dbContext.SaveChanges();
        }
    }
}