using System.Text.Json.Serialization;

namespace AiWebGymTracker.Models.BaseModels
{
    public abstract class BasePrompt
    {
        [JsonIgnore]
        public List<string> Messages { get; set; }
        protected abstract void MakePrompt(BaseInput input);
    }
}
