using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using QudiniChallenge.Contracts.PlatformSpecific;
using QudiniChallenge.Contracts.Services;
using QudiniChallenge.ViewModels.DataModels;

namespace QudiniChallenge.ViewModels
{
    public class CustomerQueueViewModel : ViewModelBase
    {
        private readonly ICustomerQueueService _service;
        private readonly IAlertService _alertService;
        private readonly IPlatformSpecificService _platformSpecificService;
        private ObservableCollection<CustomerDataModel> _customerQueue;

        public CustomerQueueViewModel(ICustomerQueueService service, IAlertService alertService, IPlatformSpecificService platformSpecificService)
        {
            _service = service;
            _alertService = alertService;
            _platformSpecificService = platformSpecificService;
        }

        public ObservableCollection<CustomerDataModel> CustomerQueue
        {
            get
            {
                return _customerQueue ?? (_customerQueue = new ObservableCollection<CustomerDataModel>());
            }
        }

        public bool IsQueueEmpty { get { return CustomerQueue.Count == 0; } }

        public async void StartQueueCheck()
        { 
            while (true)
            {
                await LoadData();
                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }

        public async Task LoadData()
        {
            var serviceReq = await _service.GetCustomerQueue();
            CustomerQueue.Clear();
            if (serviceReq.IsOk)
            {
                foreach (var customer in serviceReq.Data)
                {
                    CustomerQueue.Add(new CustomerDataModel(customer, _platformSpecificService));
                }
                RaisePropertyChanged(()=> IsQueueEmpty);
            }
            else
            {
                _alertService.ShowAlert("An Error ocurred", "an error ocurred please try again");
            }
        }
    }
}
