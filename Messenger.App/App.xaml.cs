using Messenger.App.Services;
using Messenger.App.Windows;
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

            var windowManager = _serviceProvider.GetRequiredService<WindowManager>();
            windowManager.Startup();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IValidators, DataValidators>();
            services.AddSingleton<IAuthHandler, DataController>();
            services.AddSingleton<IMessagesHandler, DataController>();
            services.AddSingleton<IAPIRequest, APIRequest>();
            services.AddSingleton<ChatsManager>();
            services.AddHttpClient();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<WindowManager>();
            services.AddSingleton<AuthorizeWindow>();
            services.AddSingleton<ChatWindow>();


            services.AddSingleton<AuthorizeVM>();
            services.AddSingleton<ChatVM>();


            return services.BuildServiceProvider();
        }
    }

}
