using Hussain.Blotters.ViewModels;
using Hussain.Infra.Core;
using Microsoft.Practices.Unity;
using Hussain.Infra.Utility;
using Hussain.Blotters.Views;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace Hussain.Blotters
{
    [Module(ModuleName="Blotter.Module")]
    [ModuleDependency("Toolbar.Module")]
    public class BlotterModule:BaseModule
    {
        public BlotterModule(IUnityContainer container, IRegionManager region, IEventAggregator evt):base(container,region,evt)
        {

        }
        protected override void RegisterTypes()
        {
            Container.RegisterType<IViewBlotterViewModel, ViewBlotterViewModel>();
        }

        protected override void InitModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.RegionBlotter,typeof(ViewBlotter));
        }
    }
}
