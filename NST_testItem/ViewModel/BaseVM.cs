using System.ComponentModel;

namespace NST_testItem.ViewModel
{
    /// <summary>
    /// Базовый класс модели-представления
    /// </summary>
    internal class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged даёт возможность сообщать об изменениях в свойствах
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
