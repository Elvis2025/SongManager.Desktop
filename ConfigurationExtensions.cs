using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SongManager.Desktop.UsesCases.Exceptions;
using SongManager.Desktop.UsesCases.IconFont;
using Syncfusion.Maui.Toolkit.Hosting;

namespace SongManager.Desktop;

public static class ConfigurationExtensions
{
    public static MauiApp CreateMauiApp(this MauiAppBuilder builder)
    {
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-solid-900.ttf", "FaSolid");
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
                fonts.AddFont("TypeIconsColor.ttf", "TypeIconsColor");
                fonts.AddFont("MaterialIcons-Regular.ttf", "IconRegular");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "IconOutlined");
                fonts.AddFont("MaterialIconsRound-Regular.otf", "IconRound");
                fonts.AddFont("MaterialIconsSharp-Regular.otf", "IconSharp");
                fonts.AddFont("MaterialIconsTwoTone-Regular.otf", "IconTwoTone");
            });


        builder.Services.AddServices();
        builder.Services.AddSingleton(FileSystem.Current);
        //builder.Services.AddHttpClient();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        {
            CrashLog.Write(e.ExceptionObject as Exception, "AppDomain.UnhandledException");
            System.Diagnostics.Debug.WriteLine("UNHANDLED (AppDomain): " + e.ExceptionObject);
        };

        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            CrashLog.Write(e.Exception, "TaskScheduler.UnobservedTaskException");
            System.Diagnostics.Debug.WriteLine("UNOBSERVED (Task): " + e.Exception);
            e.SetObserved();
        };
        return builder.Build();
    }
}
