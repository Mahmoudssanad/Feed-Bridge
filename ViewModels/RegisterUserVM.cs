using System.ComponentModel.DataAnnotations;

namespace FeedBridge_00.ViewModels
{
    public class RegisterUserVM
    {
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly Age { get; set; }
        public string? Country { get; set; }
        public string Town { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Passward")]
        public string ConfirmPassword { get; set; }


    }
}
