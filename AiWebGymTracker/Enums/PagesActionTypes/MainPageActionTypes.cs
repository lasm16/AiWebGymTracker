using AiWebGymTracker.Attributes;

namespace AiWebGymTracker.Enums.PagesActionTypes;

public enum MainPageActionTypes
{
    [PagesRouter("Training", "Index")]
    TrainService,
    [PagesRouter("Food", "Index")]
    FoodService,
    [PagesRouter("Account", "SignOutUser")]
    LogOut
}