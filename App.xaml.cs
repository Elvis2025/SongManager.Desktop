using Microsoft.Maui.Controls.PlatformConfiguration;

namespace SongManager.Desktop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {   var window = new Window(new AppShell());

#if WINDOWS
            window.Width = 1084;
            window.Height = 768;

            window.MinimumWidth = 1084;
            window.MinimumHeight = 768;
#endif
            return window;
        }
    }
}