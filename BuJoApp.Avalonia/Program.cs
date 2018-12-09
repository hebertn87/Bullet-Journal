using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using BuJoApp.Avalonia.ViewModels;
using BuJoApp.Avalonia.Views;

namespace BuJoApp.Avalonia
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowViewModel());
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
    }
}
