using AiWebGymTracker.Models.DTO;
using AiWebGymTracker.Models.DTO.AuthDTO;

namespace AiWebGymTracker.Models;

public class AuthModel
{
    public RegisterUserDto RegisterFrom { get; init; } = new();
    public SignInUserDto SignInForm { get; init; } = new();
}