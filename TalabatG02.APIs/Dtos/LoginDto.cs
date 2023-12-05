using System.ComponentModel.DataAnnotations;

namespace TalabatG02.APIs.Dtos
{
    public class LoginDto
    {
        [Required]//Email field Is Required
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }    
    }
}
