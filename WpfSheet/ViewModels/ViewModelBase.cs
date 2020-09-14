using System.ComponentModel;
using WpfSheet.Content;

namespace WpfSheet.ViewModels
{

    /// <summary>
    ///     Base ViewModel class for WpfSheet to communicate changes that are occurring
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Gets the internal <see cref="DryIoc.Container"/> instance that is meant to be used for retrieving resources
        /// </summary>
        internal DryIoc.Container Container => ResourceHandler.Container;

        /// <summary>
        ///     Updates a property with the given value and invokes <see cref="INotifyPropertyChanging"/> and <see cref="INotifyPropertyChanged"/> events
        /// </summary>
        /// <typeparam name="T">The type being updated</typeparam>
        /// <param name="property">The name of the property that is being updated</param>
        /// <param name="oldValue">A reference to the current value</param>
        /// <param name="newValue">The new value to change to</param>
        /// <remarks>If <paramref name="oldValue"/> and <paramref name="newValue"/> are identical then no change notification events occur</remarks>
        internal void Set<T>(string property, ref T oldValue, T newValue)
        {
            if (ReferenceEquals(oldValue, newValue)) return;
            OnPropertyChanging(property);
            oldValue = newValue;
            OnPropertyChanged(property);
        }

        private void OnPropertyChanged(string property)
        {
            var pc = PropertyChanged;
            pc?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void OnPropertyChanging(string property)
        {
            var pc = PropertyChanging;
            pc?.Invoke(this, new PropertyChangingEventArgs(property));
        }

    }

}
