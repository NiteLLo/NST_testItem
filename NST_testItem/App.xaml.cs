using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NST_testItem.ViewModel;
using System.Windows;

namespace NST_testItem
{
    public partial class App : Application
    {
       public App()
        {
            SetupDependencyInjection();
        }
        /// <summary>
        /// Метод установки DI контейнера
        /// </summary>
        private static void SetupDependencyInjection()
        {
            Ioc.Default.ConfigureServices(
                (IServiceProvider)new ServiceCollection()
                .AddSingleton<BaseVM>()
                .AddSingleton<MainWindowVM>()
                .BuildServiceProvider()
                );
        }
    }

}
