using Messenger.App.Services;
using Messenger.App.Services.Implementations;
using Messenger.App.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Messenger.App
{
    public partial class App : Application
    {
        private static IServiceProvider? _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _serviceProvider = ConfigureServices();

            var startupWindow = _serviceProvider.GetRequiredService<AuthorizeWindow>();
            startupWindow.Show();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Services
            services.AddSingleton<IValidators, DataValidators>();
            services.AddSingleton<IDataController, DataController>();
            services.AddSingleton<IAPIRequest, APIRequest>();
            services.AddHttpClient();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            services.AddSingleton<IConfiguration>(configuration);

            // Windows
            services.AddSingleton<AuthorizeWindow>();

            // VMs
            services.AddSingleton<AuthorizeVM>();

            return services.BuildServiceProvider();
        }
    }

}
