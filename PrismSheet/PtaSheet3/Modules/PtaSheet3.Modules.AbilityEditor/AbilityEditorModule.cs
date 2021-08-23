using Prism.Ioc;
using Prism.Modularity;

namespace PtaSheet3.Modules.AbilityEditor
{
    public class AbilityEditorModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.AbilityEditor>();
        }
    }
}