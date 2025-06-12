using Microsoft.AspNetCore.Identity;
namespace GymApp.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string DisplayName { get; set; }

    }
}
