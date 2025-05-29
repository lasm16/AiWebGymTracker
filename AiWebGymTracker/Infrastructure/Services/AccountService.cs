using AiWebGymTracker.Abstractions;
using AiWebGymTracker.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace AiWebGymTracker.Infrastructure.Services;

public class AccountService(
    UserManager<ApplicationUser> userManager, 
    SignInManager<ApplicationUser> signInManager
    ) : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    
    public async Task<IdentityResult> RegisterAsync(string email, string password, string username)
    {
        var user = new ApplicationUser { UserName = username, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user,false);
        }

        return result;
    }

    public async Task<SignInResult> LogInAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return SignInResult.Failed;
        }
        
        return await _signInManager.PasswordSignInAsync(user, password, false, false);
    }

    public Task LogOutAsync()
    {
        return _signInManager.SignOutAsync();
    }
}