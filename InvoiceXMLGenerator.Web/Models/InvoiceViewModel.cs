using System;
namespace InvoiceXMLGenerator.Web.Models
{
    public class InvoiceViewModel
    {
        public string GeneralInfoID { get; set; }
        public string GeneralInfoIssueDate { get; set; }
        public string GeneralInfoDueDate { get; set; }
        public string GeneralInfoInvoiceTypeCode { get; set; }
        public string GeneralInfoNote { get; set; }
        public string GeneralInfoNote2 { get; set; }
        public string GeneralInfoTaxPointDate { get; set; }
        public string GeneralInfoDocumentCurrencyCode { get; set; }
        public string GeneralInfoContractDocumentReference { get; set; }
        public string GeneralInfoInvoiceDocumentReference { get; set; }
        public string GeneralInfoInvoiceDocumentDate { get; set; }

        public string SellerElectonicAddress { get; set; }
        public string SellerSchemeId { get; set; }
        public string SellerPartyId { get; set; }
        public string SellerAddress { get; set; }
        public string SellerCity { get; set; }
        public string SellerPostalCode { get; set; }
        public string SellerCountrySubentity { get; set; }
        public string SellerCountry { get; set; }
        public string SellerTVID { get; set; }
        public string SellerRegistrationName { get; set; }
        public string SellerRegistrationID { get; set; }
        public string SellerCompanyLegalName { get; set; }

        public string CustomerElectonicAddress { get; set; }
        public string CustomerSchemeId { get; set; }
        public string CustomerPartyId { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountrySubentity { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerTVID { get; set; }
        public string CustomerRegistrationName { get; set; }
        public string CustomerRegistrationID { get; set; }

        public string MonetaryPaymentMeansCode { get; set; }
        public string MonetaryPayeeFinancialId { get; set; }
        public string MonetaryPayeeFinancialName { get; set; }
        public string MonetaryCustomerPaymentMeansCode { get; set; }
        public string MonetaryCustomerPayeeFinancialId { get; set; }
        public string MonetaryCustomerPayeeFinancialName { get; set; }

        public string MonetaryTaxSubtotalAmount { get; set; }
        public string MonetaryTaxAmount { get; set; }
        public string MonetaryTaxableAmount { get; set; }
        public string MonetaryTaxPercentege { get; set; }

        public string MonetaryCurency { get; set; }

        public string MonetaryLineExtensionAmount { get; set; }
        public string MonetaryTaxExclusiveAmount { get; set; }
        public string MonetaryTaxInclusiveAmount { get; set; }
        public string MonetaryPayableAmount { get; set; }

        public string LineInvoicedQuantity { get; set; }
        public string LineUnitCode { get; set; }
        public string LineLineExtensionAmount { get; set; }
        public string LineCurrency { get; set; }
        public string LineDescription { get; set; }
        public string LineName { get; set; }
        public string LineSellersItemIdentification { get; set; }
        public string LineCommodityClassification { get; set; }
        public string LineClassifiedTaxId { get; set; }
        public string LineClassifiedTaxPercent { get; set; }
        public string LinePriceAmount { get; set; }
        public string LineBaseQuantity { get; set; }
    }
}
