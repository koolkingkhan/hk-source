using Hussain.Infra.Core;
using Hussain.Infra.Events;
using Microsoft.Practices.Unity;
using System;
using Prism.Events;

namespace Hussain.Statusbars.ViewModels
{
    public class ViewStatusbarViewModel :ViewModelBase, IViewStatusbarViewModel
    {

        private string _user;
        private IUnityContainer _container;

        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private string _currentDate;
        private IEventAggregator _eventAgg;

        public string CurrentDate
        {
            get { return _currentDate; }
            set { SetProperty(ref _currentDate,value); 
            }
        }

        private string _statusmessage;

        public string StatusMessage
        {
            get { return _statusmessage; }
            set { SetProperty(ref _statusmessage,value); }
        }
        
        public ViewStatusbarViewModel(IUnityContainer container, IEventAggregator evt)
        {
            _eventAgg = evt;
            _container = container;
            User = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var service = _container.Resolve<IViewModelServices>();
            service.DateTimeTicker.Subscribe(i =>
            {
                CurrentDate=String.Format("{0}-{1}", i.Timestamp.Date.ToShortDateString(), i.Timestamp.DateTime.ToLongTimeString());
            });
            _eventAgg.GetEvent<StatusEvent>().Subscribe(i => {
               StatusMessage = i;
            });

        }
    }
}