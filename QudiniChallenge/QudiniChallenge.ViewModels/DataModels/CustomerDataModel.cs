using System;
using System.Security.Cryptography;
using System.Text;
using GalaSoft.MvvmLight;
using QudiniChallenge.Contracts.Domain;
using QudiniChallenge.Contracts.PlatformSpecific;

namespace QudiniChallenge.ViewModels.DataModels
{
    public class CustomerDataModel : ViewModelBase
    {
        private ICustomer _customer;
        private IPlatformSpecificService _platformSpecificService;

        public CustomerDataModel(ICustomer customer, IPlatformSpecificService platformSpecificService   )
        {
            _customer = customer;
            _platformSpecificService = platformSpecificService;
        }


        public string Name { get { return string.Format("{0} {1}", _customer.Name, _customer.Surname); } }

        public string Gravatar
        {
            get
            {
                if (_customer.Email != null)
                {
                      return string.Format("http://www.gravatar.com/avatar/{0}", _platformSpecificService.MD5Parse(_customer.Email));
                }
                return null;
            }
        }

        public int TimeLeftMinutes
        {
            get
            {
                DateTime startTime = DateTime.Now;

                DateTime endTime = _customer.ExpectedTime;

                TimeSpan span = endTime.Subtract(startTime);
                return span.Minutes;
            }
        }

        public int Id { get { return _customer.Id; } }

        public void Update(ICustomer customer)
        {
            _customer = customer;
            RaisePropertyChanged(()=>TimeLeftMinutes);
            RaisePropertyChanged(()=>Name);
            RaisePropertyChanged(()=>Gravatar);
        }
    }
}