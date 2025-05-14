using Messenger.App.Services;
using Messenger.App.Windows;
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

            var windowManager = _serviceProvider.GetRequiredService<WindowManager>();
            windowManager.Startup();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<DataValidators>();
            services.AddSingleton<DataController>();
            services.AddSingleton<APIRequest>();
            services.AddSingleton<ChatsManager>();
            services.AddHttpClient();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<WindowManager>();
            services.AddTransient<AuthorizeWindow>();
            services.AddTransient<ChatWindow>();


            services.AddSingleton<AuthorizeVM>();
            services.AddSingleton<ChatVM>();


            return services.BuildServiceProvider();
        }
    }

}
