using DDDSample.Domain.Models.Payment.Enums;
using DDDSample.Domain.Models.Payment.Interfaces;

namespace DDDSample.Infrastructure.Payment
{
    public static class PaymentFactory
    {
        private static AaCompany.CreditPayment? AaCompany_CreditPayment;

        public static void InitializeCreditPayment(string setting)
        {
            AaCompany_CreditPayment = new AaCompany.CreditPayment(setting);
        }

        public static ICashPayment CreateCashPayment(PaymentCompanyEnum paymentCompany)
        {
            return paymentCompany switch
            {
                PaymentCompanyEnum.AaCompany => new AaCompany.CashPayment(),
                _ => throw new ArgumentException("対応していないEnumの値です"),
            };
        }

        public static ICreditPayment CreateCreditPayment(PaymentCompanyEnum paymentCompany)
        {
            return paymentCompany switch
            {
                PaymentCompanyEnum.AaCompany => AaCompany_CreditPayment!,
                PaymentCompanyEnum.BbCompany => new BbCompany.CreditPayment(),
                _ => throw new ArgumentException("対応していないEnumの値です"),
            };
        }

        public static IBarcodePayment CreateBarcodePayment(PaymentCompanyEnum paymentCompany)
        {
            return paymentCompany switch
            {
                PaymentCompanyEnum.AaCompany => new AaCompany.BarcodePayment(),
                PaymentCompanyEnum.BbCompany => new BbCompany.BarcodePayment(),
                _ => throw new ArgumentException("対応していないEnumの値です"),
            };
        }
    }
}
