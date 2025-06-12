namespace AiWebGymTracker.Models.YandexAiModels
{
    public class CompletionOptions
    {
        public bool stream { get; set; }
        public double temperature { get; set; }
        public string maxTokens { get; set; }
        public ReasoningOptions reasoningOptions { get; set; }
    }
}