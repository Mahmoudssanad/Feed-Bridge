using System.ComponentModel.DataAnnotations;

namespace FeedBridge_00.ViewModels
{
    public class LoginUserVM
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me!!")]
        public bool RememberMe { get; set; }
    }
}
