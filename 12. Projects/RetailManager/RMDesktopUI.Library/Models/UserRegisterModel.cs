using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMDesktopUI.Library.Models
{
    public class UserRegisterModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [DisplayName("Comfirm Password")]
        [Compare(nameof(Password), ErrorMessage = "The password do not match")]
        public string ComfirmPassword { get; set; }
    }
}
