using System;
using System.Xml.Linq;

namespace InvoiceBuilder.ValueObjects
{
    public class ElementBuilder
    {
        public static XElement Build(XNamespace namespaceValue, string tag, string value)
        {
            return new XElement(namespaceValue + tag, value);
        }
    }
}
