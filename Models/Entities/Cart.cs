using FeedBridge_00.Models.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public OrderAndDonationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int User_id {  get; set; }
        public User User {  get; set; }

        public List<Product> Products { get; set; } = new();

        public List<Order> Orders { get; set; } = new();
    }
}
