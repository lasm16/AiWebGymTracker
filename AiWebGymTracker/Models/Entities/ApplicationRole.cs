using AiWebGymTracker.Models.Abstractions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class ApplicationRole : IdentityRole<int>, IEntity
    {
    }
}