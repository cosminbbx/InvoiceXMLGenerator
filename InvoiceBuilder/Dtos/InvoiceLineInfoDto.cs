using System;
namespace InvoiceBuilder.Dtos
{
    public class InvoiceLineInfoDto
    {
        public string InvoicedQuantity { get; set; }
        public string UnitCode { get; set; }
        public string LineExtensionAmount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string SellersItemIdentification { get; set; }
        public string CommodityClassification { get; set; }
        public string ClassifiedTaxId { get; set; }
        public string ClassifiedTaxPercent { get; set; }
        public string PriceAmount { get; set; }
        public string BaseQuantity { get; set; }
    }
}
