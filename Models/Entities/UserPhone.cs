using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBridge_00.Models.Entities
{
    public class UserPhone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }
    }
}
