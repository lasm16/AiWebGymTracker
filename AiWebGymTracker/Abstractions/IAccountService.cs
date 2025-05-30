using System.Security.Claims;
using AiWebGymTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace AiWebGymTracker.Abstractions;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(string email, string login, string password);
    Task<SignInResult> LogInAsync(string email, string password);
    Task LogOutAsync();
}