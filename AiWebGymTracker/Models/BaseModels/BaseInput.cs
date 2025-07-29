using System.Text.Json.Serialization;

namespace AiWebGymTracker.Models.BaseModels
{
    public abstract class BaseInput
    {
        [JsonIgnore]
        public string MessageContext { get; set; }// = "Base input";

        [JsonIgnore]
        public object InputObject { get; set; } = new object();

        public abstract void GetObject();
    }
}

