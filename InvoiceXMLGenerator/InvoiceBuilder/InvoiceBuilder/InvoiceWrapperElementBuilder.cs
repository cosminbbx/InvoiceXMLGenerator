using System;
using System.Xml.Linq;

namespace InvoiceBuilder.InvoiceBuilder
{
    public static class InvoiceWrapperElementBuilder
    {
       public static XElement Build()
        {
            XElement root = new(Namespaces.RootNamespace + "Invoice",
                new XAttribute("xmlns", Namespaces.XmlnsValue),
                new XAttribute(XNamespace.Xmlns + "cbc", Namespaces.CbcNamespace.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "cac", Namespaces.CacNamespace.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "ns4", Namespaces.Ns4Namespace.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "xsi", Namespaces.XsiNamespace),
                new XAttribute(Namespaces.XsiNamespace + "schemaLocation", Namespaces.XsiValue)
            );

            root.Add(new XElement(Namespaces.CbcNamespace + "CustomizationID", Namespaces.CustomizationID));

            return root;
        }
    }
}
