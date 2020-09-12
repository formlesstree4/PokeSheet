using System.ComponentModel;

namespace WpfSheet.ViewModels
{

    /// <summary>
    ///     Base ViewModel class for WpfSheet to communicate changes that are occurring
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        
        internal void OnPropertyChanged(string property)
        {
            var pc = PropertyChanged;
            pc?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        internal void OnPropertyChanging(string property)
        {
            var pc = PropertyChanging;
            pc?.Invoke(this, new PropertyChangingEventArgs(property));
        }

        internal void Set<T>(string property, ref T oldValue, T newValue)
        {
            if (ReferenceEquals(oldValue, newValue)) return;
            OnPropertyChanging(property);
            oldValue = newValue;
            OnPropertyChanged(property);
        }
    }

}
