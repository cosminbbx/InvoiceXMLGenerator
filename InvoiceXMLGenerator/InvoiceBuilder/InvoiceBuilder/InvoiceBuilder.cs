using System;
using System.IO;
using System.Text;
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

            root.AddSellerInfo(info.SellerInfo);

            root.AddCustomerInfo(info.CustomerInfo);

            root.AddMonetaryInfo(info.MonetaryInfo);

            root.AddInvoiceLineInfo(info.InvoiceLineInfo);

            XDocument doc = new(
                root
            );

            
            return doc;
        }

       
    }
}
