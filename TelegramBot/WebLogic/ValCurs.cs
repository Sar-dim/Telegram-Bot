using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WebLogic
{
	[XmlRoot(ElementName = "ValCurs")]
	public class ValCurs
	{
		[XmlElement(ElementName = "Valute")]
		public List<Valute> Valutes { get; set; }
		[XmlAttribute(AttributeName = "Date")]
		public string Date { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
	}
}
