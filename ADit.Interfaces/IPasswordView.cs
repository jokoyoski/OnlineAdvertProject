using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ADit.Interfaces
{
    public interface IPasswordView
    {
        string code { get; set; }

        [Required] [DisplayName("Password")] string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "wrong")]
        string ConfirmPassword { get; set; }

        int userId { get; set; }
    }
}