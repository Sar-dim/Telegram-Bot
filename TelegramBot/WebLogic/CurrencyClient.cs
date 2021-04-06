using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WebLogic
{
    public class CurrencyClient
    {
        public ValCurs ValCurs { get; set; }
        public CurrencyClient()
        {
            ValCurs = new ValCurs();
        }
        public string GetXML(string date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }
            string html = "";
            string url = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=";
            var checkedDate = DateTime.Parse(date);       
            url += checkedDate.ToString();
            WebClient client = new WebClient();
            html = client.DownloadString(url);
            return html;
        }
        public ValCurs ParseValute(string xml)
        {
            if (xml == null)
            {
                throw new ArgumentNullException(nameof(xml));
            }
            ValCurs valCurs = new ValCurs();
            using (TextReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
                valCurs = (ValCurs)serializer.Deserialize(reader);
                
            }
            return valCurs;
        }
    }
}
