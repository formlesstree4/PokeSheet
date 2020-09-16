using System;
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
        /// <param name="propertyChanged">A custom method to invoke in addition to <see cref="OnPropertyChanged(string)"/></param>
        /// <param name="propertyChanging">A custom method to invoke in addition to <see cref="OnPropertyChanging(string)"/></param>
        /// <param name="others">Additional properties to be invoked</param>
        /// <remarks>
        ///     If <paramref name="oldValue"/> and <paramref name="newValue"/> are identical then no change notification events occur.
        ///     Additionally, the built in notification methods are invoked first BEFORE the custom handlers.
        ///     If the handlers for <see cref="OnPropertyChanging(string)"/> or <paramref name="propertyChanging"/> throw an Exception, the property WILL NOT CHANGE.
        ///     If the handlers for <see cref="OnPropertyChanged(string)"/> or <paramref name="propertyChanged"/> throw an Exception, the <paramref name="others"/> collection will not be iterated.
        /// </remarks>
        internal void Set<T>(
            string property,
            ref T oldValue,
            T newValue,
            Action propertyChanged = null,
            Action propertyChanging = null,
            params string[] others)
        {
            if (ReferenceEquals(oldValue, newValue)) return;
            OnPropertyChanging(property);
            propertyChanging?.Invoke();
            oldValue = newValue;
            OnPropertyChanged(property);
            propertyChanged?.Invoke();
            foreach (var other in others) OnPropertyChanged(other);
        }

        /// <summary>
        ///     Raises <see cref="INotifyPropertyChanged.PropertyChanged"/> for the supplied property
        /// </summary>
        /// <param name="property">The name of the property that has been changed</param>
        /// <remarks>This method should be invoked AFTER the data in the property has been altered</remarks>
        internal void OnPropertyChanged(string property)
        {
            var pc = PropertyChanged;
            pc?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        ///     Raises <see cref="INotifyPropertyChanging.PropertyChanging"/> for the supplied property
        /// </summary>
        /// <param name="property">The name of the property that has been changed</param>
        /// <remarks>This method should be invoked BEFORE the data in the property has been altered</remarks>
        internal void OnPropertyChanging(string property)
        {
            var pc = PropertyChanging;
            pc?.Invoke(this, new PropertyChangingEventArgs(property));
        }

    }

}
