using FeedBridge_00.Models.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public OrderAndDonationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Admin_id {  get; set; }
        public Admin Admin { get; set; } = new();

        public int User_id { get; set; }
        public User User { get; set; } = new();

        public int Delivery_id { get; set; }
        public Delivery Delivery { get; set; } = new();

        public int Cart_id { get; set; }
        public Cart Cart { get; set; } = new();
    }
}
