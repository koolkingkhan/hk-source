using Hussain.Infra.Core;
using Hussain.Services.Utility;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace Hussain.Services
{
    [Module(ModuleName="Services.Module")]
    public class ServicesModule:BaseModule
    {
        public ServicesModule(IUnityContainer container, IRegionManager region, IEventAggregator evt) : base(container, region, evt) { }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IViewModelServices, ViewModelServices>(new ContainerControlledLifetimeManager());
        }

        protected override void InitModule()
        {
        
        }
    }
}
