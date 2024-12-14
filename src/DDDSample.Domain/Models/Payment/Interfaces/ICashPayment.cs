using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Domain.Models.Payment.Interfaces
{
    /// <summary>
    /// 現金決済
    /// </summary>
    public interface ICashPayment
    {
        Task Pay(int amount);
    }
}
