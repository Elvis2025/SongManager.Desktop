using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongManager.Desktop.Utilities
{
    public static class SongManagerApp
    {
        public static T CreateInstance<T>() where T : class
        {
            return ActivatorUtilities.GetServiceOrCreateInstance<T>(Application.Current!.Handler.MauiContext!.Services!);
        }
    }
}
