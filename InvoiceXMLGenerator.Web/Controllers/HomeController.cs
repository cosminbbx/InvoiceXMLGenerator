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

        [HttpGet]
        public IActionResult Index()
        {
            InvoiceViewModel formData = new()
            {
                GeneralInfoID = "129",
                GeneralInfoIssueDate = "2022-08-29",
                GeneralInfoDueDate = "2022-09-29",
                GeneralInfoInvoiceTypeCode = "380-FACTURA",
                GeneralInfoNote = "RO86TREZ406501503X023745 - Trezoreria IASI",
                GeneralInfoNote2 = "Proces verbal de predare din 04.12.2019",
                GeneralInfoTaxPointDate = "2022-08-31",
                GeneralInfoDocumentCurrencyCode = "RON",
                GeneralInfoContractDocumentReference = "Contract 1323/26.01.2022",

                SellerElectonicAddress = "ctirpescu@yahoo.com",
                SellerSchemeId = "EM",
                SellerPartyId = "12056072",
                SellerAddress = "PASCANI, STRADA MOLDOVEI NR.37",
                SellerCity = "PASCANI",
                SellerPostalCode = "705200",
                SellerCountrySubentity = "RO-IS",
                SellerCountry = "RO",
                SellerTVID = "RO12056072",
                SellerRegistrationName = "S.C.LIGANT-PROD S.R.L.",
                SellerRegistrationID = "J22/579/1999",
                SellerCompanyLegalName = "Capital social subscris si varsat:200 lei",

                CustomerElectonicAddress = "exemple@gmail.com",
                CustomerSchemeId = "EM",
                CustomerPartyId = "9768500",
                CustomerAddress = "JUD. IASI, MUN. IASI, STR. COSTACHE NEGRI, NR.48",
                CustomerCity = "IASI",
                CustomerCountrySubentity = "IS",
                CustomerCountry = "RO",
                CustomerTVID = "9768500",
                CustomerRegistrationName = "OFICIUL DE CADASTRU SI PUBLICITATE IMOBILIARA IASI",
                CustomerRegistrationID = "9768500",

                MonetaryPaymentMeansCode = "42",
                MonetaryPayeeFinancialId = "RO88TREZ4075069XXX002585",
                MonetaryPayeeFinancialName = "TREZORERIA MUN PASCANI",
                MonetaryCustomerPaymentMeansCode = "42",
                MonetaryCustomerPayeeFinancialId = "RO61BTRLRONCRT0221263901",
                MonetaryCustomerPayeeFinancialName = "TRANSILVANIA",

                MonetaryTaxAmount = "1225.00",
                MonetaryCurency = "RON",
                MonetaryLineExtensionAmount = "932.24",
                MonetaryTaxExclusiveAmount = "932.24",
                MonetaryTaxInclusiveAmount = "1109.37",
                MonetaryPayableAmount = "1109.37",

                LineInvoicedQuantity = "1.000",
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
                LineBaseQuantity = "1.000"
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
                    CustomerPaymentMeansCode = formData.MonetaryCustomerPaymentMeansCode,
                    CustomerPayeeFinancialId = formData.MonetaryCustomerPayeeFinancialId,
                    CustomerPayeeFinancialName = formData.MonetaryCustomerPayeeFinancialName,
                    TaxAmount = formData.MonetaryTaxAmount,
                    Curency = "RON",
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
                    Currency = "RON",
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
