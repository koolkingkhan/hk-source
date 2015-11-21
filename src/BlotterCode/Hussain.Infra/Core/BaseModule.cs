using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace Hussain.Infra.Core
{
    public abstract class BaseModule : IModule
    {
        public BaseModule(IUnityContainer container, IRegionManager region, IEventAggregator evt)
        {
            Container = container;
            RegionManager = region;
            EventAggregator = evt;
        }

        protected IEventAggregator EventAggregator { get; private set; }
        protected IRegionManager RegionManager { get; private set; }
        protected IUnityContainer Container { get; private set; }

        public void Initialize()
        {
            RegisterTypes();
            InitModule();
        }

        protected abstract void RegisterTypes();
        protected abstract void InitModule();
    }
}