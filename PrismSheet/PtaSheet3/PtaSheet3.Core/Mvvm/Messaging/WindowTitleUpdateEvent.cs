using Prism.Events;

namespace PtaSheet3.Core.Mvvm.Messaging
{

    /// <summary>
    /// Message used to change the window title
    /// </summary>
    public sealed class WindowTitleUpdateEvent : PubSubEvent<string> { }

}
