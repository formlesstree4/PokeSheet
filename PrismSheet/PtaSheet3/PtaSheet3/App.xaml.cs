﻿using Prism.Ioc;
using Prism.Modularity;
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
            // containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<PtaSheet3.Modules.SheetModule.SheetModuleModule>();
        }
    }
}
