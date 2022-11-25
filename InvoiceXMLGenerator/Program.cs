using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using InvoiceBuilder;

namespace InvoiceXMLGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var info = new InvoiceInfoDto()
            {
                GeneralInfo = new InvoiceBuilder.Dtos.GeneralInfoDto()
                {
                    ID = "129",
                    IssueDate = "2022-08-29",
                    DueDate = "2022-09-29",
                    InvoiceTypeCode = "380",
                    Note = "RO86TREZ406501503X023745 - Trezoreria IASI",
                    Note2 = "Proces verbal de predare din 04.12.2019",
                    TaxPointDate = "2022-08-31",
                    DocumentCurrencyCode = "RON",
                    ContractDocumentReference = "Framework test"
                },
                SellerInfo = new InvoiceBuilder.Dtos.PartyInfoDto()
                {
                    ElectonicAddress = "infostargroup@gmail.com",
                    SchemeId = "EM",
                    PartyId = "99887766",
                    Address = "Main street 1",
                    City = "Pascani",
                    PostalCode = "705200",
                    CountrySubentity = "RO-IS",
                    Country = "RO",
                    TVID = "GB1232434",
                    RegistrationName = "SupplierOfficialName Ltd",
                    RegistrationID = "GB983294",
                    CompanyLegalName = "CompanyLegalName"
                },
                CustomerInfo = new InvoiceBuilder.Dtos.PartyInfoDto()
                {
                    ElectonicAddress = "test@gmail.com",
                    SchemeId = "EM",
                    PartyId = "99887766",
                    Address = "Main street 1",
                    City = "Pascani",
                    CountrySubentity = "RO-IS",
                    Country = "RO",
                    TVID = "GB1232434",
                    RegistrationName = "SupplierOfficialName Ltd",
                    RegistrationID = "GB983294"
                },
                MonetaryInfo = new InvoiceBuilder.Dtos.MonetaryInfoDto()
                {
                    PaymentMeansCode = "30",
                    PayeeFinancialId = "IBAN32423940",
                    PayeeFinancialName = "AccountName",
                    TaxAmount = "1225.00",
                    Curency = "RON",
                    LineExtensionAmount = "5900",
                    TaxExclusiveAmount = "5901",
                    TaxInclusiveAmount = "5902",
                    PayableAmount = "5903"
                },
                InvoiceLineInfo = new InvoiceBuilder.Dtos.InvoiceLineInfoDto()
                {
                    InvoicedQuantity = "1.001",
                    UnitCode = "H87",
                    LineExtensionAmount = "932.24",
                    Currency = "RON",
                    Description = "Refacturare partiala factura fiscala de energie electrica seria MS eon nr. 130014915904/27.08.2022 aferenta consumului inregistrat la sediul B.C.P.I. Pascani,cf.Contract inchiriere 2273/30.09.2019.",
                    Name = "Refacturare energie electrica",
                    SellersItemIdentification = "104",
                    CommodityClassification = "71314100-3",
                    ClassifiedTaxId = "S",
                    ClassifiedTaxPercent = "19",
                    PriceAmount = "932.240",
                    BaseQuantity = "1.002"
                }
            };
            WriteXMLToFile(InvoiceBuilder.InvoiceBuilder.InvoiceBuilder.Build(info));
        }

        static void WriteXMLToFile(XDocument doc)
        {
            doc.Declaration = new XDeclaration("1.0", "UTF-8", null);
            StringWriter writer = new Utf8StringWriter();
            doc.Save(writer, SaveOptions.None);
            Console.WriteLine(writer);

            File.WriteAllText(@"/Users/cosmin/Desktop/XMLTest/hereIam2.xml", writer.ToString(), Encoding.UTF8);
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
    }
}
