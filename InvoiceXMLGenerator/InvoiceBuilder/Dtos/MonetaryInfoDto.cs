using System;
namespace InvoiceBuilder.Dtos
{
    public class MonetaryInfoDto
    {
        public string PaymentMeansCode { get; set; }
        public string PayeeFinancialId { get; set; }
        public string PayeeFinancialName { get; set; }

        public string TaxAmount { get; set; }
        public string Curency { get; set; }

        public string LineExtensionAmount { get; set; }
        public string TaxExclusiveAmount { get; set; }
        public string TaxInclusiveAmount { get; set; }
        public string PayableAmount { get; set; }
    }
}
