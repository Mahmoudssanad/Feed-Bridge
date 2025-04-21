namespace FeedBridge_00.Models.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public List<User> Users { get; set; } = new();

        public List<Report> Reports { get; set; } = new();

        public List<Review> Reviews { get; set; } = new();

        public List<InventoryEmployee> InventoryEmployees { get; set; } = new();

        public List<Donation> Donations { get; set; } = new();

        public List<Product> Products { get; set; } = new();

        public List<Order> Orders { get; set; } = new();
    }
}
