using System.Windows;
using WpfSheet.Content;

namespace WpfSheet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {

            // Load the JSON file here for all the necessary types
            // and then register them with DryIoc.
            ResourceHandler.Initialize();

        }

    }
}
