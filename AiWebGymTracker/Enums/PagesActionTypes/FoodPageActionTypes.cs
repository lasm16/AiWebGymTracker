using AiWebGymTracker.Attributes;

namespace AiWebGymTracker.Enums.PagesActionTypes;

public enum FoodPageActionTypes
{
    [PagesRouter("Food", "AddNutrition")]
    Add,
    [PagesRouter("Food", "GetNutrition")]
    Get,
    [PagesRouter("Food", "Home")]
    Home
}