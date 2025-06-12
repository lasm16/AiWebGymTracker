

using AiWebGymTracker.Models.BaseModels;

namespace AiWebGymTracker.Abstractions
{
    public interface IAiService
    {
        Task<TResponse> AskAi<TJsonInput, TResponse>(TJsonInput prompt)
            where TResponse : class, new()
            where TJsonInput : BaseInput;
    }
}
