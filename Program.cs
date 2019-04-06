using System;
using Gtk;
using QuickLaunchPanel.UI;

namespace QuickLaunchPanel
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            IO.CheckCreateConfig();
            Application.Init();
            Controller.LoadEntries();
            var app = new Application("org.QuickLaunchPanel.QuickLaunchPanel", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            app.AddWindow(win);

            win.Show();
            Application.Run();
            Controller.SaveEntries();
        }
    }
}
