using System;
namespace InvoiceBuilder.Dtos
{
    public class PartyInfoDto
    {
        public string ElectonicAddress { get; set; }
        public string SchemeId { get; set; }
        public string PartyId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountrySubentity { get; set; }
        public string Country { get; set; }
        public string TVID { get; set; }
        public string RegistrationName { get; set; }
        public string RegistrationID { get; set; }
        public string CompanyLegalName { get; set; }
    }
}
