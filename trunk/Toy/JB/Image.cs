/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JeebookToy.JB
{
	/// <summary>
	/// Description of Image.
	/// </summary>
	public class Image
	{
		public Image()
		{
		}
		
		public string Fileref { get; set; }
		
		public System.Xml.XmlElement ToXmlElement(System.Xml.XmlDocument doc)
		{
			if ( Fileref == null || Fileref == "" )
				return null;
			
			System.Xml.XmlElement elem = doc.CreateElement("mediaobject");
			System.Xml.XmlElement elem2 = doc.CreateElement("imageobject");
			System.Xml.XmlElement elem3 = doc.CreateElement("imagedata");
			System.Xml.XmlAttribute attr = doc.CreateAttribute("fileref");
			attr.Value = Fileref;
			
			elem3.Attributes.Append( attr );
			
			elem.AppendChild( elem2 );
			elem2.AppendChild( elem3 );
			
			return elem;
		}
	}
}
