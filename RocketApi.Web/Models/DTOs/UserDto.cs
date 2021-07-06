using System.Text.Json.Serialization;

namespace RocketApi.Web.Models.DTOs
{
    public class UserDto
    {
        [JsonPropertyName("screen_name")]
        public string ScreenName { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
