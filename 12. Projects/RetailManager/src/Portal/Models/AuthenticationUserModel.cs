using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class AuthenticationUserModel
    {
        [Required(ErrorMessage = "Email Address is required.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password id required.")]
        public string Password { get; set; } = string.Empty;
    }
}
