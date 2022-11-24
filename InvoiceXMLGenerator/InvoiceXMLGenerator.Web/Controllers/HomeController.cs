using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InvoiceXMLGenerator.Web.Models;
using InvoiceBuilder;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace InvoiceXMLGenerator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            InvoiceViewModel formData = new()
            {
                GeneralInfoID = "129",
                GeneralInfoIssueDate = "2022-08-29",
                GeneralInfoDueDate = "2022-09-29",
                GeneralInfoInvoiceTypeCode = "380",
                GeneralInfoNote = "RO86TREZ406501503X023745 - Trezoreria IASI",
                GeneralInfoNote2 = "Proces verbal de predare din 04.12.2019",
                GeneralInfoTaxPointDate = "2022-08-31",
                GeneralInfoDocumentCurrencyCode = "RON",
                GeneralInfoContractDocumentReference = "Framework test",

                SellerElectonicAddress = "infostargroup@gmail.com",
                SellerSchemeId = "EM",
                SellerPartyId = "99887766",
                SellerAddress = "Main street 1",
                SellerCity = "Pascani",
                SellerPostalCode = "705200",
                SellerCountrySubentity = "RO-IS",
                SellerCountry = "RO",
                SellerTVID = "GB1232434",
                SellerRegistrationName = "SupplierOfficialName Ltd",
                SellerRegistrationID = "GB983294",
                SellerCompanyLegalName = "CompanyLegalName",

                CustomerElectonicAddress = "test@gmail.com",
                CustomerSchemeId = "EM",
                CustomerPartyId = "99887766",
                CustomerAddress = "Main street 1",
                CustomerCity = "Pascani",
                CustomerCountrySubentity = "RO-IS",
                CustomerCountry = "RO",
                CustomerTVID = "GB1232434",
                CustomerRegistrationName = "SupplierOfficialName Ltd",
                CustomerRegistrationID = "GB983294",

                MonetaryPaymentMeansCode = "30",
                MonetaryPayeeFinancialId = "IBAN32423940",
                MonetaryPayeeFinancialName = "AccountName",
                MonetaryTaxAmount = "1225.00",
                MonetaryCurency = "RON",
                MonetaryLineExtensionAmount = "5900",
                MonetaryTaxExclusiveAmount = "5901",
                MonetaryTaxInclusiveAmount = "5902",
                MonetaryPayableAmount = "5903",

                LineInvoicedQuantity = "1.001",
                LineUnitCode = "H87",
                LineLineExtensionAmount = "932.24",
                LineCurrency = "RON",
                LineDescription = "Refacturare partiala factura fiscala de energie electrica seria MS eon nr. 130014915904/27.08.2022 aferenta consumului inregistrat la sediul B.C.P.I. Pascani,cf.Contract inchiriere 2273/30.09.2019.",
                LineName = "Refacturare energie electrica",
                LineSellersItemIdentification = "104",
                LineCommodityClassification = "71314100-3",
                LineClassifiedTaxId = "S",
                LineClassifiedTaxPercent = "19",
                LinePriceAmount = "932.240",
                LineBaseQuantity = "1.002"
            };

            return View(formData);
        }

        [HttpPost]
        public FileContentResult Index(InvoiceViewModel formData)
        {
            var info = new InvoiceInfoDto()
            {
                GeneralInfo = new InvoiceBuilder.Dtos.GeneralInfoDto()
                {
                    ID = formData.GeneralInfoID,
                    IssueDate = formData.GeneralInfoIssueDate,
                    DueDate = formData.GeneralInfoDueDate,
                    InvoiceTypeCode = formData.GeneralInfoInvoiceTypeCode,
                    Note = formData.GeneralInfoNote,
                    Note2 = formData.GeneralInfoNote2,
                    TaxPointDate = formData.GeneralInfoTaxPointDate,
                    DocumentCurrencyCode = formData.GeneralInfoDocumentCurrencyCode,
                    ContractDocumentReference = formData.GeneralInfoContractDocumentReference
                },
                SellerInfo = new InvoiceBuilder.Dtos.PartyInfoDto()
                {
                    ElectonicAddress = formData.SellerElectonicAddress,
                    SchemeId = formData.SellerSchemeId,
                    PartyId = formData.SellerPartyId,
                    Address = formData.SellerAddress,
                    City = formData.SellerCity,
                    PostalCode = formData.SellerPostalCode,
                    CountrySubentity = formData.SellerCountrySubentity,
                    Country = formData.SellerCountry,
                    TVID = formData.SellerTVID,
                    RegistrationName = formData.SellerRegistrationName,
                    RegistrationID = formData.SellerRegistrationID,
                    CompanyLegalName = formData.SellerCompanyLegalName
                },
                CustomerInfo = new InvoiceBuilder.Dtos.PartyInfoDto()
                {
                    ElectonicAddress = formData.CustomerElectonicAddress,
                    SchemeId = formData.CustomerSchemeId,
                    PartyId = formData.CustomerPartyId,
                    Address = formData.CustomerAddress,
                    City = formData.CustomerCity,
                    CountrySubentity = formData.CustomerCountrySubentity,
                    Country = formData.CustomerCountry,
                    TVID = formData.CustomerTVID,
                    RegistrationName = formData.CustomerRegistrationName,
                    RegistrationID = formData.CustomerRegistrationID
                },
                MonetaryInfo = new InvoiceBuilder.Dtos.MonetaryInfoDto()
                {
                    PaymentMeansCode = formData.MonetaryPaymentMeansCode,
                    PayeeFinancialId = formData.MonetaryPayeeFinancialId,
                    PayeeFinancialName = formData.MonetaryPayeeFinancialName,
                    TaxAmount = formData.MonetaryTaxAmount,
                    Curency = formData.MonetaryCurency,
                    LineExtensionAmount = formData.MonetaryLineExtensionAmount,
                    TaxExclusiveAmount = formData.MonetaryTaxExclusiveAmount,
                    TaxInclusiveAmount = formData.MonetaryTaxInclusiveAmount,
                    PayableAmount = formData.MonetaryPayableAmount
                },
                InvoiceLineInfo = new InvoiceBuilder.Dtos.InvoiceLineInfoDto()
                {
                    InvoicedQuantity = formData.LineInvoicedQuantity,
                    UnitCode = formData.LineUnitCode,
                    LineExtensionAmount = formData.LineLineExtensionAmount,
                    Currency = formData.LineCurrency,
                    Description = formData.LineDescription,
                    Name = formData.LineName,
                    SellersItemIdentification = formData.LineSellersItemIdentification,
                    CommodityClassification = formData.LineCommodityClassification,
                    ClassifiedTaxId = formData.LineClassifiedTaxId,
                    ClassifiedTaxPercent = formData.LineClassifiedTaxPercent,
                    PriceAmount = formData.LinePriceAmount,
                    BaseQuantity = formData.LineBaseQuantity
                }
            };

            var doc = InvoiceBuilder.InvoiceBuilder.InvoiceBuilder.Build(info);
            doc.Declaration = new XDeclaration("1.0", "UTF-8", null);
            StringWriter writer = new Utf8StringWriter();
            doc.Save(writer, SaveOptions.None);
            byte[] bytes = Encoding.ASCII.GetBytes(writer.ToString());

            return File(bytes, "text/xml", "Factura_" + $"{Guid.NewGuid()}.xml");
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
