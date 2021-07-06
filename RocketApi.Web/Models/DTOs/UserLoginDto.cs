using System.ComponentModel.DataAnnotations;

namespace RocketApi.Web.Models.DTOs
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
