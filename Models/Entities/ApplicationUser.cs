using FeedBridge_00.Models.Status;
using Microsoft.AspNetCore.Identity;

namespace FeedBridge_00.Models.Entities
{
    // IdentityUser => String بتاعه نوعه Id اللي هو ال  NonGeneric كدا انا بورث من ال 
    public class ApplicationUser : IdentityUser
    {
        // Add properties on IdentityUser ( IdentityUser عشان لو انا محتاج اضيف حاجه مش موجوده في ال )
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateOnly BirthDate { get; set; }
        public UserStatus Status { get; set; }


        
    }
}
