using FeedBridge_00.Models.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class Donation
    {
        public int Id { get; set; }
        public TypeStatus Type { get; set; }
        public int Quantity { get; set; }
        public OrderAndDonationStatus Status { get; set; }
        public DateTime Expiration { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Delivery_id { get; set; }
        public Delivery Delivery { get; set; }

        public int User_id { get; set; }
        public User User { get; set; }

        public int Admin_id { get; set; }
        public Admin Admin { get; set; }
    }
}
