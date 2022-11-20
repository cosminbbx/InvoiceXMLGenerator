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
                    Note = "RO86TREZ406501503X023745 - Trezoreria IASI#Proces verbal de predare din 04.12.2019",
                    TaxPointDate = "2022-08-31",
                    DocumentCurrencyCode = "RON"
                }
            };
            WriteXMLToFile(InvoiceBuilder.InvoiceBuilder.InvoiceBuilder.Build(info));
        }

        static void WriteXMLToFile(XDocument doc)
        {
            StringBuilder sb = new();
            XmlWriterSettings xws = new()
            {
                Indent = true
            };

            using (XmlWriter xw = XmlWriter.Create(sb, xws))
            {
                doc.Save(xw);
            }

            using StreamWriter file = new(@"/Users/virgacosmin/Desktop/XMLTest/hereIam.xml");
            file.WriteLine(sb.ToString());
        }
    }
}
