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
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "TaxPointDate", info.TaxPointDate));
            root.Add(ElementBuilder.Build(Namespaces.CbcNamespace, "DocumentCurrencyCode", info.DocumentCurrencyCode));

            return root;
        }
    }
}
