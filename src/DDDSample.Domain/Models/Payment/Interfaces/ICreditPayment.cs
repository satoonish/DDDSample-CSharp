using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Domain.Models.Payment.Interfaces
{
    /// <summary>
    /// クレジット決済
    /// </summary>
    public interface ICreditPayment
    {
        Task Pay(int amount);

        Task Cancel(int amount);

        Task QueryAvailable();
    }
}
