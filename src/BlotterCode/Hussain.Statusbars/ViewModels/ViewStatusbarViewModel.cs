using System;
using System.Security.Principal;
using Hussain.Infra.Core;
using Hussain.Infra.Events;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace Hussain.Statusbars.ViewModels
{
    public class ViewStatusbarViewModel : ViewModelBase, IViewStatusbarViewModel
    {
        private readonly IUnityContainer _container;

        private string _currentDate;
        private readonly IEventAggregator _eventAgg;

        private string _statusmessage;

        private string _user;

        public ViewStatusbarViewModel(IUnityContainer container, IEventAggregator evt)
        {
            _eventAgg = evt;
            _container = container;
            User = WindowsIdentity.GetCurrent().Name;
            var service = _container.Resolve<IViewModelServices>();
            service.DateTimeTicker.Subscribe(
                i =>
                {
                    CurrentDate = string.Format("{0}-{1}", i.Timestamp.Date.ToShortDateString(),
                        i.Timestamp.DateTime.ToLongTimeString());
                });
            _eventAgg.GetEvent<StatusEvent>().Subscribe(i => { StatusMessage = i; });
        }

        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public string CurrentDate
        {
            get { return _currentDate; }
            set { SetProperty(ref _currentDate, value); }
        }

        public string StatusMessage
        {
            get { return _statusmessage; }
            set { SetProperty(ref _statusmessage, value); }
        }
    }
}