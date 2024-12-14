using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Domain.Models.Payment.Interfaces
{
    /// <summary>
    /// バーコード決済
    /// </summary>
    public interface IBarcodePayment
    {
        Task Pay(int amount);

        Task Pay(int amount, string barcode);

        Task Cancel(int amount);
    }
}
