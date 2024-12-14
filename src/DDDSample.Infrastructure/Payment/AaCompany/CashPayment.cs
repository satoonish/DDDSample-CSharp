using DDDSample.Domain.Models.Payment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Infrastructure.Payment.AaCompany
{
    internal class CashPayment : ICashPayment
    {
        public Task Pay(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
