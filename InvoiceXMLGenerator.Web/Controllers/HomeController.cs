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

                CustomerElectonicAddress = "economic.is@ancpi.ro",
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
                    ElectonicAddress = string.IsNullOrEmpty(formData.SellerElectonicAddress) ? "" : formData.SellerElectonicAddress,
                    SchemeId = string.IsNullOrEmpty(formData.SellerSchemeId) ? "" : formData.SellerSchemeId,
                    PartyId = string.IsNullOrEmpty(formData.SellerPartyId) ? "" : formData.SellerPartyId,
                    Address = string.IsNullOrEmpty(formData.SellerAddress) ? "" : formData.SellerAddress,
                    City = string.IsNullOrEmpty(formData.SellerCity) ? "" : formData.SellerCity,
                    PostalCode = string.IsNullOrEmpty(formData.SellerPostalCode) ? "" : formData.SellerPostalCode,
                    CountrySubentity = string.IsNullOrEmpty(formData.SellerCountrySubentity) ? "" : formData.SellerCountrySubentity,
                    Country = string.IsNullOrEmpty(formData.SellerCountry) ? "" : formData.SellerCountry,
                    TVID = string.IsNullOrEmpty(formData.SellerTVID) ? "" : formData.SellerTVID,
                    RegistrationName = string.IsNullOrEmpty(formData.SellerRegistrationName) ? "" : formData.SellerRegistrationName,
                    RegistrationID = string.IsNullOrEmpty(formData.SellerRegistrationID) ? "" : formData.SellerRegistrationID,
                    CompanyLegalName = string.IsNullOrEmpty(formData.SellerCompanyLegalName) ? "" : formData.SellerCompanyLegalName
                },
                CustomerInfo = new InvoiceBuilder.Dtos.PartyInfoDto()
                {
                    ElectonicAddress = string.IsNullOrEmpty(formData.CustomerElectonicAddress) ? "" : formData.CustomerElectonicAddress,
                    SchemeId = string.IsNullOrEmpty(formData.CustomerSchemeId) ? "" : formData.CustomerSchemeId,
                    PartyId = string.IsNullOrEmpty(formData.CustomerPartyId) ? "" : formData.CustomerPartyId,
                    Address = string.IsNullOrEmpty(formData.CustomerAddress) ? "" : formData.CustomerAddress,
                    City = string.IsNullOrEmpty(formData.CustomerCity) ? "" : formData.CustomerCity,
                    CountrySubentity = string.IsNullOrEmpty(formData.CustomerCountrySubentity) ? "" : formData.CustomerCountrySubentity,
                    Country = string.IsNullOrEmpty(formData.CustomerCountry) ? "" : formData.CustomerCountry,
                    TVID = string.IsNullOrEmpty(formData.CustomerTVID) ? "" : formData.CustomerTVID,
                    RegistrationName = string.IsNullOrEmpty(formData.CustomerRegistrationName) ? "" : formData.CustomerRegistrationName,
                    RegistrationID = string.IsNullOrEmpty(formData.CustomerRegistrationID) ? "" : formData.CustomerRegistrationID
                },
                MonetaryInfo = new InvoiceBuilder.Dtos.MonetaryInfoDto()
                {
                    PaymentMeansCode = string.IsNullOrEmpty(formData.MonetaryPaymentMeansCode) ? "" : formData.MonetaryPaymentMeansCode,
                    PayeeFinancialId = string.IsNullOrEmpty(formData.MonetaryPayeeFinancialId) ? "" : formData.MonetaryPayeeFinancialId,
                    PayeeFinancialName = string.IsNullOrEmpty(formData.MonetaryPayeeFinancialName) ? "" : formData.MonetaryPayeeFinancialName,
                    CustomerPaymentMeansCode = string.IsNullOrEmpty(formData.MonetaryCustomerPaymentMeansCode) ? "" : formData.MonetaryCustomerPaymentMeansCode,
                    CustomerPayeeFinancialId = string.IsNullOrEmpty(formData.MonetaryCustomerPayeeFinancialId) ? "" : formData.MonetaryCustomerPayeeFinancialId,
                    CustomerPayeeFinancialName = string.IsNullOrEmpty(formData.MonetaryCustomerPayeeFinancialName) ? "" : formData.MonetaryCustomerPayeeFinancialName,
                    TaxAmount = string.IsNullOrEmpty(formData.MonetaryTaxAmount) ? "" : formData.MonetaryTaxAmount,
                    Curency = "RON",
                    LineExtensionAmount = string.IsNullOrEmpty(formData.MonetaryLineExtensionAmount) ? "" : formData.MonetaryLineExtensionAmount,
                    TaxExclusiveAmount = string.IsNullOrEmpty(formData.MonetaryTaxExclusiveAmount) ? "" : formData.MonetaryTaxExclusiveAmount,
                    TaxInclusiveAmount = string.IsNullOrEmpty(formData.MonetaryTaxInclusiveAmount) ? "" : formData.MonetaryTaxInclusiveAmount,
                    PayableAmount = string.IsNullOrEmpty(formData.MonetaryPayableAmount) ? "" : formData.MonetaryPayableAmount
                },
                InvoiceLineInfo = new InvoiceBuilder.Dtos.InvoiceLineInfoDto()
                {
                    InvoicedQuantity = string.IsNullOrEmpty(formData.LineInvoicedQuantity) ? "" : formData.LineInvoicedQuantity,
                    UnitCode = string.IsNullOrEmpty(formData.LineUnitCode) ? "" : formData.LineUnitCode,
                    LineExtensionAmount = string.IsNullOrEmpty(formData.LineLineExtensionAmount) ? "" : formData.LineLineExtensionAmount,
                    Currency = "RON",
                    Description = string.IsNullOrEmpty(formData.LineDescription) ? "" : formData.LineDescription,
                    Name = string.IsNullOrEmpty(formData.LineName) ? "" : formData.LineName,
                    SellersItemIdentification = string.IsNullOrEmpty(formData.LineSellersItemIdentification) ? "" : formData.LineSellersItemIdentification,
                    CommodityClassification = string.IsNullOrEmpty(formData.LineCommodityClassification) ? "" : formData.LineCommodityClassification,
                    ClassifiedTaxId = string.IsNullOrEmpty(formData.LineClassifiedTaxId) ? "" : formData.LineClassifiedTaxId,
                    ClassifiedTaxPercent = string.IsNullOrEmpty(formData.LineClassifiedTaxPercent) ? "" : formData.LineClassifiedTaxPercent,
                    PriceAmount = string.IsNullOrEmpty(formData.LinePriceAmount) ? "" : formData.LinePriceAmount,
                    BaseQuantity = string.IsNullOrEmpty(formData.LineBaseQuantity) ? "" : formData.LineBaseQuantity
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
