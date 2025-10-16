using System.Reflection;

namespace SongManager.Desktop.Utilities;

public static class SongManagerApp
{
    public static T CreateInstance<T>() where T : class
    {
        return ActivatorUtilities.GetServiceOrCreateInstance<T>(Application.Current!.Handler.MauiContext!.Services!);
    }

    public static void RegisterAsRoutes()
    {
        var typesWithAttr = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a =>
            {
                try { return a.GetTypes(); }
                catch { return Array.Empty<Type>(); }
            })
            .Where(t => t.IsClass && !t.IsAbstract &&
                        t.GetCustomAttribute<RegisterAsRouteAttribute>() is not null &&
                        typeof(Page).IsAssignableFrom(t));

        foreach (var type in typesWithAttr)
        {
            var attr = type.GetCustomAttribute<RegisterAsRouteAttribute>()!;
            var route = attr.RouteName ?? type.Name;
            Routing.RegisterRoute(route, type);
        }
    }
}
