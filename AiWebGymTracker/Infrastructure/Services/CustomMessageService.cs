using AiWebGymTracker.Abstractions;
using AiWebGymTracker.Enums;

namespace AiWebGymTracker.Infrastructure.Services;

public class CustomMessageService : ICustomMessageProvider
{
    private readonly Dictionary<CustomMessageTypes, Func<string>> _handlers = 
        new Dictionary<CustomMessageTypes, Func<string>>
        {
            { CustomMessageTypes.SignInFailed, () => "Пароль или логин введены неверно"}
        };

    public string GetMessage(CustomMessageTypes type)
    {
        if (_handlers.TryGetValue(type, out var handler))
        {
            return handler();
        }
        else
        {
            throw new KeyNotFoundException($"Не обнаржуен делегат для типа {type.ToString()}");
        }
    }
}