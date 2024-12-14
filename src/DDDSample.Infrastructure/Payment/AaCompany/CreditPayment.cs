using DDDSample.Domain.Models.Payment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Infrastructure.Payment.AaCompany
{
    internal class CreditPayment : ICreditPayment
    {
        private string InitialSetting = string.Empty;

        public CreditPayment(string initialSetting)
        {
            InitialSetting = initialSetting;
        }

        public Task Cancel(int amount)
        {
            throw new NotImplementedException();
        }

        public Task Pay(int amount)
        {
            throw new NotImplementedException();
        }

        public Task QueryAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
