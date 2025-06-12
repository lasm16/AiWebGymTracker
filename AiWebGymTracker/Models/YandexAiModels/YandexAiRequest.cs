using AiWebGymTracker.Models.BaseModels;
using System.Text.Json;

namespace AiWebGymTracker.Models.YandexAiModels
{
    public class YandexAiRequest<TResponse> : BasePrompt
        where TResponse : class, new()
    {
        public required string modelUri { get; set; }
        public CompletionOptions completionOptions { get; set; } = new CompletionOptions()
        {
            stream = false,
            temperature = 0.6,
            maxTokens = "2000"
        };
        public List<Message> messages { get; set; } = new List<Message>();

        public YandexAiRequest(BaseInput input)
        {
            MakePrompt(input);
        }

        protected override void MakePrompt(BaseInput input)
        {
            messages = new List<Message>()
            {
                new Message()
                {
                    role = "system",
                    text = input.MessageContext
                },
                new Message()
                {
                    role = "user",
                    text = JsonSerializer.Serialize(input)
                },
                new Message()
                {
                    role = "user",
                    text = $"Верни ответ в таком формате json:\n{JsonSerializer.Serialize(new TResponse())}"
                }
            };
        }
    }
}
