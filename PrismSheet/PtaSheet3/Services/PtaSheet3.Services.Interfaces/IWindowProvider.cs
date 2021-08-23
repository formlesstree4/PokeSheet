namespace PtaSheet3.Services.Interfaces
{

    /// <summary>
    /// Provides some hooks to have adjustments made to the current host window
    /// </summary>
    public interface IWindowProvider
    {

        /// <summary>
        /// Sets the window title to be something else
        /// </summary>
        /// <param name="title">The new window title</param>
        /// <param name="keepPrefix">Indicates whether or not the title of the window can start with 'PtaSheet - '</param>
        void SetWindowTitle(string title, bool keepPrefix = true);

    }
}
