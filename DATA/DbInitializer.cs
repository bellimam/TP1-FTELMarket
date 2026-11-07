using FTELMarket.API.Models;

namespace FTELMarket.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "PlayStation 5" },
                    new Category { Name = "Nintendo Switch" },
                    new Category { Name = "Xbox Series X" },
                    new Category { Name = "PC" }
                );
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "Utilisateur démo"
                });
            }

            context.SaveChanges();
        }
    }
}