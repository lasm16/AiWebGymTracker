
using AiWebGymTracker.Models.BaseModels;
using AiWebGymTracker.Models.Enums;

namespace AiWebGymTracker.Models
{
    public class UserStatsInput : BaseInput
    {
        public UserStatsInput() 
        {
            base.MessageContext = "Ты - фитнесс тренер. Необходимо составить план тренировок на неделю полагаясь на параметры ниже";
        }

        public int Age { get; set; }
        public float Weight { get; set; } // кг
        public float Height { get; set; } // см
        public Gender Gender { get; set; } // enum
        public FitnessLevel Level { get; set; } // Новичок/Средний/Профи
        public string[] Goals { get; set; } // ["Похудение", "Мышечная масса"]

        public override void GetObject()
        {
            base.InputObject = this;
        }
    }
}
