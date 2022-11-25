using System;
namespace InvoiceBuilder.Dtos
{
    public class GeneralInfoDto
    {
        public string ID { get; set; }
        public string IssueDate { get; set; }
        public string DueDate { get; set; }
        public string InvoiceTypeCode { get; set; }
        public string Note { get; set; }
        public string Note2 { get; set; }
        public string TaxPointDate { get; set; }
        public string DocumentCurrencyCode { get; set; }
        public string ContractDocumentReference { get; set; }
    }
}
