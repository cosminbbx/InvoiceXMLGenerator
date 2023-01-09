using System;
using System.Xml.Linq;

namespace InvoiceBuilder
{
    public static class Namespaces
    {
        public static string XmlnsValue = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";
        public static string XsiValue = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2 http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-Invoice-2.1.xsd";
        public static string CustomizationID = "urn:cen.eu:en16931:2017#compliant#urn:efactura.mfinante.ro:CIUS-RO:1.0.1";
        public static XNamespace CbcNamespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
        public static XNamespace CacNamespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
        public static XNamespace Ns4Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
        public static XNamespace RootNamespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";
        public static XNamespace XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";
    }
}
