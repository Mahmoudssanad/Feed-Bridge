using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Admin_id { get; set; }
        public Admin Admin { get; set; }

        public int User_id { get; set; }
        public User User { get; set; }

        public Notification Notification { get; set; }
    }
}
