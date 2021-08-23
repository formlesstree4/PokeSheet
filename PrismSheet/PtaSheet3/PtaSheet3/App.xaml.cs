using Prism.Ioc;
using Prism.Modularity;
using PtaSheet3.Services;
using PtaSheet3.Services.Interfaces;
using PtaSheet3.Views;
using System.Windows;


namespace PtaSheet3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IWindowProvider, WindowProvider>();
            containerRegistry.RegisterSingleton<IAbilityDataProvider, AbilityDataProvider>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Modules.Sheet.SheetModule>();
            moduleCatalog.AddModule<Modules.AbilityEditor.AbilityEditorModule>();
        }
    }
}
