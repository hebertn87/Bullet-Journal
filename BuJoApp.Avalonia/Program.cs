using System;
using System.IO;
using Avalonia;
using Avalonia.Logging.Serilog;
using BuJoApp.Avalonia.ViewModels;
using BuJoApp.Avalonia.Views;
using BuJoApp.DB;
using BuJoApp.Interfaces;

namespace BuJoApp.Avalonia
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataStore dataStore;

            string dbPath = null;
            string dbName = "BulletJournal.db";

            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);

            dataStore = new SqliteDataStore(dbPath);

            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowViewModel(dataStore));
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
    }
}
