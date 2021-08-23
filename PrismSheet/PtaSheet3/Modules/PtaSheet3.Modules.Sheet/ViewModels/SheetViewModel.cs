using Prism.Mvvm;
using Prism.Regions;
using PtaSheet3.Services.Interfaces;

namespace PtaSheet3.Modules.Sheet.ViewModels
{
    public class SheetViewModel : BindableBase, IRegionMemberLifetime
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public bool KeepAlive => false;

        public SheetViewModel(IAbilityDataProvider abilityProvider, IWindowProvider windowProvider)
        {
            var random = new System.Random();
            windowProvider.SetWindowTitle($"ViewA ({random.Next()})");
            Message = "View A from your Prism Module";
        }
    }
}
