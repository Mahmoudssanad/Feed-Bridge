using FeedBridge_00.Models.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class Support
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Curreny { get; set; }
        public SupportStatus Status { get; set; }// 'pending', 'completed', 'failed', 'refunded'
        public string TransacionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int User_id {  get; set; }
        public User User {  get; set; }
    }
}
