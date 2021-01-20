using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserToRegister
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        [Required, MinLength(6)]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}