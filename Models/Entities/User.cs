using FeedBridge_00.Models.Status;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Admin_id {  get; set; }
        public Admin Admin {  get; set; }

        public List<UserPhone> PhoneNumbers { get; set; } = new();

        public List<Donation> Donations { get; set; } = new();

        public List<Cart> Carts { get; set; } = new();

        public List<Order> Orders { get; set; } = new();

        public List<Review> Reviews { get; set; } = new();

        public List<Report> Reports { get; set; } = new();
        public List<Support> Supports { get; set; } = new();
        public List<Notification> Notifications { get; set; } = new();

    }
}
