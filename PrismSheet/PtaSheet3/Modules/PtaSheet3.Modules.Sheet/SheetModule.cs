using Prism.Ioc;
using Prism.Modularity;

namespace PtaSheet3.Modules.Sheet
{
    public class SheetModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.Sheet>();
        }
    }
}