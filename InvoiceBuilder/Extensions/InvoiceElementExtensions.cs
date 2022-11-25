using System;
using System.Xml.Linq;
using InvoiceBuilder.Dtos;
using InvoiceBuilder.ValueObjects;

namespace InvoiceBuilder.Extensions
{
    public static class InvoiceElementExtensions
    {
        public static XElement AddGeneralInfo(this XElement root, GeneralInfoDto info)
        {
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "ID", info.ID));
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "IssueDate", info.IssueDate));
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "DueDate", info.DueDate));
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "InvoiceTypeCode", info.InvoiceTypeCode));
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "Note", info.Note));
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "Note", info.Note2));
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "TaxPointDate", info.TaxPointDate));
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "DocumentCurrencyCode", info.DocumentCurrencyCode));

            var element = new XElement(Namespaces.CacNamespace + "ContractDocumentReference");
            element.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "ID", info.ContractDocumentReference));

            root.Add(element);

            return root;
        }

        public static XElement AddSellerInfo(this XElement root, PartyInfoDto info)
        {
            root.Add(new XElement(Namespaces.CacNamespace + "AccountingSupplierParty",
                new XElement(Namespaces.CacNamespace + "Party",
                    new XElement(Namespaces.CbcNamespace + "EndpointID", info.ElectonicAddress, new XAttribute("schemeID", info.SchemeId)),
                    new XElement(Namespaces.CacNamespace + "PartyIdentification", new XElement(Namespaces.CbcNamespace + "ID", info.PartyId)),
                    new XElement(Namespaces.CacNamespace + "PostalAddress",
                        new XElement(Namespaces.CbcNamespace + "StreetName", info.Address),
                        new XElement(Namespaces.CbcNamespace + "CityName", info.City),  
                        new XElement(Namespaces.CbcNamespace + "PostalZone", info.PostalCode),
                        new XElement(Namespaces.CbcNamespace + "CountrySubentity", info.CountrySubentity),
                        new XElement(Namespaces.CacNamespace + "Country", new XElement(Namespaces.CbcNamespace + "IdentificationCode", info.Country))),
                    new XElement(Namespaces.CacNamespace + "PartyTaxScheme",
                        new XElement(Namespaces.CbcNamespace + "CompanyID", info.TVID),
                        new XElement(Namespaces.CacNamespace + "TaxScheme", new XElement(Namespaces.CbcNamespace + "ID", "VAT"))),
                    new XElement(Namespaces.CacNamespace + "PartyLegalEntity",
                        new XElement(Namespaces.CbcNamespace + "RegistrationName", info.RegistrationName),
                        new XElement(Namespaces.CbcNamespace + "CompanyID", info.RegistrationID),
                        new XElement(Namespaces.CbcNamespace + "CompanyLegalForm", info.CompanyLegalName)))));

            return root;
        }

        public static XElement AddCustomerInfo(this XElement root, PartyInfoDto info)
        {
            root.Add(new XElement(Namespaces.CacNamespace + "AccountingCustomerParty",
                new XElement(Namespaces.CacNamespace + "Party",
                    new XElement(Namespaces.CbcNamespace + "EndpointID", info.ElectonicAddress, new XAttribute("schemeID", info.SchemeId)),
                    new XElement(Namespaces.CacNamespace + "PartyIdentification", new XElement(Namespaces.CbcNamespace + "ID", info.PartyId)),
                    new XElement(Namespaces.CacNamespace + "PostalAddress",
                        new XElement(Namespaces.CbcNamespace + "StreetName", info.Address),
                        new XElement(Namespaces.CbcNamespace + "CityName", info.City),
                        new XElement(Namespaces.CbcNamespace + "CountrySubentity", info.CountrySubentity),
                        new XElement(Namespaces.CacNamespace + "Country", new XElement(Namespaces.CbcNamespace + "IdentificationCode", info.Country))),
                    new XElement(Namespaces.CacNamespace + "PartyTaxScheme",
                        new XElement(Namespaces.CbcNamespace + "CompanyID", info.TVID),
                        new XElement(Namespaces.CacNamespace + "TaxScheme", new XElement(Namespaces.CbcNamespace + "ID", "VAT"))),
                    new XElement(Namespaces.CacNamespace + "PartyLegalEntity",
                        new XElement(Namespaces.CbcNamespace + "RegistrationName", info.RegistrationName),
                        new XElement(Namespaces.CbcNamespace + "CompanyID", info.RegistrationID)))));

            return root;
        }

        public static XElement AddMonetaryInfo(this XElement root, MonetaryInfoDto info)
        {
            root.Add(new XElement(Namespaces.CacNamespace + "PaymentMeans",
                new XElement(Namespaces.CbcNamespace + "PaymentMeansCode", info.PaymentMeansCode, new XAttribute("name", "Credit transfer")),
                new XElement(Namespaces.CacNamespace + "PayeeFinancialAccount",
                    new XElement(Namespaces.CbcNamespace + "ID", info.PayeeFinancialId),
                    new XElement(Namespaces.CbcNamespace + "Name", info.PayeeFinancialName))));

            root.Add(new XElement(Namespaces.CacNamespace + "PaymentMeans",
                new XElement(Namespaces.CbcNamespace + "PaymentMeansCode", info.CustomerPaymentMeansCode, new XAttribute("name", "Credit transfer")),
                new XElement(Namespaces.CacNamespace + "PayeeFinancialAccount",
                    new XElement(Namespaces.CbcNamespace + "ID", info.CustomerPayeeFinancialId),
                    new XElement(Namespaces.CbcNamespace + "Name", info.CustomerPayeeFinancialName))));

            root.Add(new XElement(Namespaces.CacNamespace + "TaxTotal",
                new XElement(Namespaces.CbcNamespace + "TaxAmount", info.TaxAmount, new XAttribute("currencyID", info.Curency))));

            root.Add(new XElement(Namespaces.CacNamespace + "LegalMonetaryTotal",
                new XElement(Namespaces.CbcNamespace + "LineExtensionAmount", info.LineExtensionAmount, new XAttribute("currencyID", info.Curency)),
                new XElement(Namespaces.CbcNamespace + "TaxExclusiveAmount", info.TaxExclusiveAmount, new XAttribute("currencyID", info.Curency)),
                new XElement(Namespaces.CbcNamespace + "TaxInclusiveAmount", info.TaxInclusiveAmount, new XAttribute("currencyID", info.Curency)),
                new XElement(Namespaces.CbcNamespace + "PayableAmount", info.PayableAmount, new XAttribute("currencyID", info.Curency))));
                
            return root;
        }
        public static XElement AddInvoiceLineInfo(this XElement root, InvoiceLineInfoDto info)
        {
            root.Add(new XElement(Namespaces.CacNamespace + "InvoiceLine",
               new XElement(Namespaces.CbcNamespace + "ID", "1"),
               new XElement(Namespaces.CbcNamespace + "InvoicedQuantity", info.InvoicedQuantity, new XAttribute("unitCode", info.UnitCode)),
               new XElement(Namespaces.CbcNamespace + "LineExtensionAmount", info.LineExtensionAmount, new XAttribute("currencyID", info.Currency)),
               new XElement(Namespaces.CacNamespace + "Item",
                   new XElement(Namespaces.CbcNamespace + "Description", info.Description),
                   new XElement(Namespaces.CbcNamespace + "Name", info.Name),
                   new XElement(Namespaces.CacNamespace + "SellersItemIdentification", new XElement(Namespaces.CbcNamespace + "ID", info.SellersItemIdentification)),
                   new XElement(Namespaces.CacNamespace + "CommodityClassification", new XElement(Namespaces.CbcNamespace + "ItemClassificationCode", info.CommodityClassification, new XAttribute("listID", "STI"))),
                   new XElement(Namespaces.CacNamespace + "ClassifiedTaxCategory",
                       new XElement(Namespaces.CbcNamespace + "ID", info.ClassifiedTaxId),
                       new XElement(Namespaces.CbcNamespace + "Percent", info.ClassifiedTaxPercent),
                       new XElement(Namespaces.CacNamespace + "TaxScheme", new XElement(Namespaces.CbcNamespace + "ID", "VAT")))),
               new XElement(Namespaces.CacNamespace + "Price",
                   new XElement(Namespaces.CbcNamespace + "PriceAmount", info.PriceAmount, new XAttribute("currencyID", info.Currency)),
                   new XElement(Namespaces.CbcNamespace + "BaseQuantity", info.BaseQuantity, new XAttribute("unitCode", info.UnitCode)))));

            return root;
        }
    }
}
