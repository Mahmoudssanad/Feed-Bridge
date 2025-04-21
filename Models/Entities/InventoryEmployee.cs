using FeedBridge_00.Models.Status;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class InventoryEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Admin_id { get; set; }
        public Admin Admin { get; set; }

        public List<Delivery> Deliveries {  get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
