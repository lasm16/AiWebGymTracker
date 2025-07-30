using AiWebGymTracker.Enums;
using AiWebGymTracker.Infrastructure.Abstractions;
using AiWebGymTracker.Models;
using AiWebGymTracker.Models.DTO.AuthDTO;
using Microsoft.AspNetCore.Mvc;

namespace AiWebGymTracker.Controllers;

public class AccountController(IAccountService accountService, ICustomMessageProvider messageProvider) : Controller
{
    private readonly IAccountService _accountService = accountService;
    private readonly ICustomMessageProvider _customMessageProvider = messageProvider;

    [HttpGet]
    public IActionResult Auth()
    {
        return View(new AuthModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterUser([Bind(Prefix = "RegisterFrom")] RegisterUserDto dto)
    {
        var result = await _accountService.RegisterAsync(dto.Email, dto.Password, dto.Username);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
            
        return View("Auth", new AuthModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignInUser([Bind(Prefix = "SignInForm")] SignInUserDto dto)
    {
        var result = await _accountService.LogInAsync(dto.Email, dto.Password);

        if (result.Succeeded)
        {
            return RedirectToAction("index", "Home");
        }
        
        ModelState.AddModelError(string.Empty, _customMessageProvider.GetMessage(CustomMessageTypes.SignInFailed));

        return View("Auth", new AuthModel());
    }

    [HttpPost]
    public async Task<IActionResult> SignOutUser()
    {
        await _accountService.LogOutAsync();
        
        Console.WriteLine("User has been logged out");
        
        return RedirectToAction("Auth", "Account");
    }
}