using AiWebGymTracker.Enums;

namespace AiWebGymTracker.Abstractions;

public interface ICustomMessageProvider
{
    public string GetMessage(CustomMessageTypes type);
}