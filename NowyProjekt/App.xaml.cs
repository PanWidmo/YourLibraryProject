using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NowyProjekt.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace NowyProjekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary> 
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<LibraryContext>(option =>
            {
                option.UseSqlite("Data Source = Library.db");
            });

            services.AddSingleton<MainWindow>();

            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartUp(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
