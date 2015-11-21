using Hussain.Blotters.ViewModels;
using Hussain.Blotters.Views;
using Hussain.Infra.Core;
using Hussain.Infra.Utility;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace Hussain.Blotters
{
    [Module(ModuleName = "Blotter.Module")]
    [ModuleDependency("Toolbar.Module")]
    public class BlotterModule : BaseModule
    {
        public BlotterModule(IUnityContainer container, IRegionManager region, IEventAggregator evt)
            : base(container, region, evt)
        {
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IViewBlotterViewModel, ViewBlotterViewModel>();
        }

        protected override void InitModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.RegionBlotter, typeof (ViewBlotter));
        }
    }
}