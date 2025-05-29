using Microsoft.AspNetCore.Identity;

namespace AiWebGymTracker.Models.Entities
{
    public class ApplicationUser : IdentityUser<int>, IEntity
    {
    }
}
