using Microsoft.AspNetCore.Identity;

namespace RocketApi.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }
    }
}
