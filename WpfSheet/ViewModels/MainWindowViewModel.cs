using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfSheet.Mvvm;

namespace WpfSheet.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private int _selectedTabIndex;

        public ICommand AddNewTabCommand { get; }

        public ObservableCollection<SheetViewModel> Sheets { get; private set; } = new ObservableCollection<SheetViewModel>();

        public int SelectedTabIndex { get => _selectedTabIndex; set => Set(nameof(SelectedTabIndex), ref _selectedTabIndex, value); }


        public MainWindowViewModel()
        {
            AddNewTabCommand = new RelayCommand(() =>
            {
                Sheets.Add(new SheetViewModel());
                SelectedTabIndex = Sheets.Count - 1;
            });
        }

    }

}
