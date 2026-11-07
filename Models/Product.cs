namespace FTELMarket.API.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        // Relation avec User
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // Relation avec Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}