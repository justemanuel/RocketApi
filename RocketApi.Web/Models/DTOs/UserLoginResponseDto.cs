using System.Collections.Generic;

namespace RocketApi.Web.Models.DTOs
{
    public class UserLoginResponseDto
    {
        public string Token { get; set; }
        public bool Logged { get; set; }
        public List<string> Errors { get; set; }
    }
}
