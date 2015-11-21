using Hussain.Infra.Core;
using Microsoft.Practices.Unity;
using Hussain.Infra.Utility;
using Hussain.Toolbars.Views;
using Hussain.Toolbars.ViewModels;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace Hussain.Toolbars
{
    [Module(ModuleName="Toolbar.Module")]
   public class ToolbarModule:BaseModule
    {
        public ToolbarModule(IUnityContainer container, IRegionManager region, IEventAggregator evt):base(container,region,evt)
        {

        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IViewToolbarViewModel, ViewToolbarViewModel>();
        }

        protected override void InitModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.RegionToolbar, typeof(ViewToolbar));
        }
    }
}
