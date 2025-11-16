using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using UdmurtRace.DAL;
using UdmurtRace.DAL.Repositories;
using UdmurtRace.Domain.Abstractions.Repositories;
using UdmurtRace.Domain.Entities;
using UdmurtRaceAvalonia.ViewModels;
using UdmurtRaceAvalonia.Views;

namespace UdmurtRaceAvalonia
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        public override void Initialize()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            AvaloniaXamlLoader.Load(this);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql("User ID=postgres; database=UdmurtRace; HOST=localhost; Port=5432; Password=12345678;"));

            //services.AddScoped(typeof(IClientRepository<>), typeof(ClientRepository<>));
            //services.AddScoped(typeof(IRaceRepository<>), typeof(RaceRepository<>));
            //services.AddScoped(typeof(ISaleRepository<>), typeof(SaleRepository<>));

            services.AddScoped<IClientRepository<ClientEntity>, ClientRepository<ClientEntity>>();
            services.AddScoped<IRaceRepository<RaceEntity>, RaceRepository<RaceEntity>>();
            services.AddScoped<ISaleRepository<SaleEntity>, SaleRepository<SaleEntity>>();

            services.AddTransient<MainWindowViewModel>();
        }


        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();
                var mainWindow = _serviceProvider.GetRequiredService<MainWindowViewModel>();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = mainWindow,
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
    }
}