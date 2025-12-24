using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Nakara_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceProvider = ConfigureServices();
            MainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton(sp => new MainWindow
            {
                DataContext = sp.GetRequiredService<MainWindowViewModel>(),
            });
            return services.BuildServiceProvider();
        }
    }
}
