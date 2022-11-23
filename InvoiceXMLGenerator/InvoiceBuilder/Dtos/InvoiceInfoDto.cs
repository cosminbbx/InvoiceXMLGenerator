using System;
using InvoiceBuilder.Dtos;

namespace InvoiceBuilder
{
    public class InvoiceInfoDto
    {
        public GeneralInfoDto GeneralInfo { get; set; }
        public PartyInfoDto SellerInfo { get; set; }
        public PartyInfoDto CustomerInfo { get; set; }
        public MonetaryInfoDto MonetaryInfo { get; set; }
        public InvoiceLineInfoDto InvoiceLineInfo { get; set; }
    }
}
