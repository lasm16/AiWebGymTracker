using AiWebGymTracker.Abstractions;

namespace AiWebGymTracker.Infrastructure.Services;

public class CustomMessageService : ICustomMessageProvider
{
    public string UnauthorizedErrorMessage => GetUnauthorizedErrorMessage();

    private static string GetUnauthorizedErrorMessage()
    {
        return "Логин или пароль ведены неверно";
    }
}