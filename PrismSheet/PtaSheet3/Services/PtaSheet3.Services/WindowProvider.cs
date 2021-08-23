using Prism.Events;
using PtaSheet3.Core.Mvvm.Messaging;
using PtaSheet3.Services.Interfaces;

namespace PtaSheet3.Services
{
    public sealed class WindowProvider : IWindowProvider
    {

        private readonly WindowTitleUpdateEvent updateEvent;

        public WindowProvider(IEventAggregator eventAggregator)
        {
            updateEvent = eventAggregator.GetEvent<WindowTitleUpdateEvent>();
        }

        public void SetWindowTitle(string title, bool keepPrefix)
        {
            updateEvent.Publish(keepPrefix ? $"PtaSheet - {title}" : title);
        }
    }
}
