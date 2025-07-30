using AiWebGymTracker.Attributes;

namespace AiWebGymTracker.Enums.PagesActionTypes;

public enum TrainingPageActionTypes
{
    [PagesRouter("Training", "AddTraining")]
    Add,
    [PagesRouter("Training", "GetTraining")]
    Get,
    [PagesRouter("Training", "Home")]
    Home
    
}