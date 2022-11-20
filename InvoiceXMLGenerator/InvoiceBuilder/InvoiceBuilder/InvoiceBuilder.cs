using System;
using System.Xml.Linq;
using InvoiceBuilder.Extensions;
using InvoiceBuilder.ValueObjects;

namespace InvoiceBuilder.InvoiceBuilder
{
    [Serializable]
    public static class InvoiceBuilder
    {
        public static XDocument Build(InvoiceInfoDto info)
        {
            var root = InvoiceWrapperElementBuilder.Build();

            root.AddGeneralInfo(info.GeneralInfo);

            XDocument doc = new(
                new XDeclaration("1.0", "utf-8", "yes"),
                root
            );
            return doc;
        }
    }
}
