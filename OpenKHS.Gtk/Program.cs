using System;
using Gtk;
using Ninject;
using OpenKHS.Data.StaticData;
using OpenKHS.ViewModels;

namespace OpenKHS.Gtk
{
    class Program
    {
        private static IKernel _kernel;

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.OpenKHS.Gtk.OpenKHS.Gtk", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            _kernel = new StandardKernel(
                new ViewModelCoreBindings(),
                new DbContextBindings(DbConnectionStrings.LIVE));

            var win = _kernel.Get<MainWindow>();
            app.AddWindow(win);

            win.Show();
            Application.Run();
        }
    }
}
