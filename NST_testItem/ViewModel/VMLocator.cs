using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace NST_testItem.ViewModel
{
    /// <summary>
    /// Класс локатора для распредления моделей представления
    /// </summary>
    internal class VMLocator
    {
        public MainWindowVM MainWindowVM => Ioc.Default.GetService<MainWindowVM>();
    }
}
