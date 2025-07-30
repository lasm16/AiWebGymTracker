using System.Reflection;
using AiWebGymTracker.Attributes;
using AiWebGymTracker.Enums;


namespace AiWebGymTracker.Infrastructure.Utils.WebRouters;

public static class PageRouter
{
    public static (string Controller, string Action) GetRoute<T>(T service) where T: Enum
    {
        var serviceInfo = typeof(T).GetMember(service.ToString())[0];
        var attribute = serviceInfo.GetCustomAttribute<PagesRouterAttribute>();
        
        return attribute != null ? (attribute.Controller, attribute.Action) : ("Home", "Index");
    }
}