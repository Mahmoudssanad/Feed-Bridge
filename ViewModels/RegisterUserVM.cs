using System.ComponentModel.DataAnnotations;

namespace FeedBridge_00.ViewModels
{
    public class RegisterUserVM
    {
        //[Required]
        //[Display(Name = "UserName")]
        //public string? Name { get; set; }
        //public string PhoneNumber { get; set; }
        //public DateOnly Age { get; set; }
        //public string? Country { get; set; }
        //public string Town { get; set; }
        //[DataType(DataType.EmailAddress)]
        //[Required]
        //public string Email { get; set; }

        //[DataType(DataType.Password)]
        //public string Password { get; set; }
        //[DataType(DataType.Password)]
        //[Compare("Password")]
        //[Display(Name = "Confirm Passward")]
        //public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Town is required")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}
