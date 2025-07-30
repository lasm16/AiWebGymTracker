using AiWebGymTracker.Enums;

namespace AiWebGymTracker.Infrastructure.Abstractions;

public interface ICustomMessageProvider
{
    public string GetMessage(CustomMessageTypes type);
}