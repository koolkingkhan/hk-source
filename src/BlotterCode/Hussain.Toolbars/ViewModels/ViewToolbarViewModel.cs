using Prism.Events;

namespace Hussain.Toolbars.ViewModels
{
    public class ViewToolbarViewModel : IViewToolbarViewModel
    {
        private IEventAggregator _eventAgg;


        public ViewToolbarViewModel(IEventAggregator evt)
        {
            _eventAgg = evt;
        }
    }
}