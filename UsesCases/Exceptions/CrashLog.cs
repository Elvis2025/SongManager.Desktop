using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongManager.Desktop.UsesCases.Exceptions
{
    public static class CrashLog
    {
        public static void Write(Exception ex, string origin)
        {
            try
            {
                var folder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "SongManager");
                Directory.CreateDirectory(folder);
                var path = Path.Combine(folder, "crash.log");
                File.AppendAllText(path,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {origin}\n{ex}\n\n");
            }
            catch { /* no-op */ }
        }
    }
}
