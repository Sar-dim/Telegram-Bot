using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WebLogic
{
	[XmlRoot(ElementName = "Valute")]
	public class Valute
	{
		[XmlElement(ElementName = "NumCode")]
		public string NumCode { get; set; }
		[XmlElement(ElementName = "CharCode")]
		public string CharCode { get; set; }
		[XmlElement(ElementName = "Nominal")]
		public string Nominal { get; set; }
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "Value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
	}
}
