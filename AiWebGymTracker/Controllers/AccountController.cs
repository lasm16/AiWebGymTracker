using AiWebGymTracker.Abstractions;
using AiWebGymTracker.Models;
using AiWebGymTracker.Models.DTO.AuthDTO;
using Microsoft.AspNetCore.Mvc;

namespace AiWebGymTracker.Controllers;

public class AccountController(IAccountService accountService) : Controller
{
    private readonly IAccountService _accountService = accountService;

    [HttpGet]
    public IActionResult Auth()
    {
        return View(new AuthModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterUser([Bind(Prefix = "RegisterUser")] RegisterUserDto dto)
    {
        var result = await _accountService.RegisterAsync(dto.Email, dto.Password, dto.Username);

        if (result.Succeeded) return RedirectToAction("Index", "Home");
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }
            
        dto.Email = string.Empty;
        dto.Password = string.Empty;
        dto.Username = string.Empty;
            
        return View("Auth", new AuthModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SigninUser([Bind(Prefix = "SigninUser")] SigninUserDto dto)
    {
        var result = await _accountService.LoginAsync(dto.Email, dto.Password);

        if (result.Succeeded) return RedirectToAction("index", "Home");
        
        ModelState.AddModelError(string.Empty, "Логин или пароль ведены неверно");
        dto.Email = string.Empty;
        dto.Password = string.Empty;

        return View("Auth", new AuthModel());
    }

    [HttpPost]
    public async Task<IActionResult> SignoutUser()
    {
        await _accountService.LogoutAsync();
        
        return RedirectToAction("Auth", "Account");
    }
}