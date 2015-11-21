using Hussain.Infra.Core;
using Hussain.Infra.Utility;
using Hussain.Statusbars.ViewModels;
using Hussain.Statusbars.Views;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace Hussain.Statusbars
{
    [Module(ModuleName = "Statusbar.Module")]
    [ModuleDependency("Services.Module")]
    public class StatusbarModule : BaseModule
    {
        public StatusbarModule(IUnityContainer container, IRegionManager region, IEventAggregator evt)
            : base(container, region, evt)
        {
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IViewStatusbarViewModel, ViewStatusbarViewModel>();
        }

        protected override void InitModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.RegionStatus, typeof (ViewStatusbar));
        }
    }
}