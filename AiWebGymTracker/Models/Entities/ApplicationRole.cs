using AiWebGymTracker.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace AiWebGymTracker.Models.Entities
{
    public class ApplicationRole : IdentityRole<int>, IEntity
    {
    }
}