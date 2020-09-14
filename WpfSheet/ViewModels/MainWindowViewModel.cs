using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfSheet.Mvvm;

namespace WpfSheet.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {


        public ICommand AddNewTabCommand { get; }

        public ObservableCollection<SheetViewModel> Sheets { get; private set; } = new ObservableCollection<SheetViewModel>();




        public MainWindowViewModel()
        {
            AddNewTabCommand = new RelayCommand(() =>
            {
                Sheets.Add(new SheetViewModel());
            });
        }

    }

}
