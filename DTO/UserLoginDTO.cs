using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserLoginDTO
    {
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; } = null!;
        [StringLength(maximumLength: 20, ErrorMessage = "password too long")]
        public string Password { get; set; } = null!;
    }
}