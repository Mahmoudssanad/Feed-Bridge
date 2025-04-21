using System.ComponentModel.DataAnnotations;

namespace FeedBridge_00.ViewModels
{
    public class LoginUserVM
    {
        [Display(Name = "البريد الإلكتروني", Prompt = "أدخل بريدك الإلكتروني")]
        public string Email { get; set; }

        [Display(Name = "كلمة المرور", Prompt = "أدخل كلمة المرور")]
        public string Password { get; set; }

        [Display(Name = "تذكرني")]
        public bool RememberMe { get; set; }
    }
}
