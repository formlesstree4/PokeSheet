using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace PtaSheet3.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "PtaSheet";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public DelegateCommand NewCommand { get; private set; }

        public DelegateCommand EditAbilitiesCommand { get; private set; }


        public MainWindowViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _ = eventAggregator.GetEvent<Core.Mvvm.Messaging.WindowTitleUpdateEvent>().Subscribe(title => Title = title, ThreadOption.UIThread);
            NewCommand = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate(Core.RegionNames.ContentRegion, "Sheet");
            });
            EditAbilitiesCommand = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate(Core.RegionNames.ContentRegion, "AbilityEditor");
            });
        }
    }
}
