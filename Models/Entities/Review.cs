using FeedBridge_00.Models.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public ReviewStatus Status { get; set; } // تظهر ولا لا 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Admin_id { get; set; }
        public Admin Admin { get; set; }

        public int User_id { get; set; }
        public User User { get; set; }
    }
}
