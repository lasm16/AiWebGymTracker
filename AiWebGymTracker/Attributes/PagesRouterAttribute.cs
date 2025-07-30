namespace AiWebGymTracker.Attributes;

public class PagesRouterAttribute(string controller, string action) : Attribute
{
    public string Controller { get; } = controller;
    public string Action { get; } = action;
}