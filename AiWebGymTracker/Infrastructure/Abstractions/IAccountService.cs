using Microsoft.AspNetCore.Identity;

namespace AiWebGymTracker.Infrastructure.Abstractions;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(string email, string login, string password);
    Task<SignInResult> LogInAsync(string email, string password);
    Task LogOutAsync();
}