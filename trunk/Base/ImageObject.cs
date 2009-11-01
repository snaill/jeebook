/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Xml.Linq;

namespace Jeebook.Base
{
	/// <summary>
    /// Description of ImageObject.
	/// </summary>
	public class ImageObject
	{
        public static ImageObject Create(XElement xe)
        {
            ImageObject io = new ImageObject();

            XElement elem = xe.Element("imagedata");
            io.FileRef = elem.Attribute("fileref").Value;
            io.Value = elem.Value;

            return io;
        }

		public System.Xml.XmlElement ToXmlElement(System.Xml.XmlDocument doc)
		{
            if (FileRef == null || FileRef == "")
				return null;
			
			System.Xml.XmlElement elem = doc.CreateElement("mediaobject");
			System.Xml.XmlElement elem2 = doc.CreateElement("imageobject");
			System.Xml.XmlElement elem3 = doc.CreateElement("imagedata");
			System.Xml.XmlAttribute attr = doc.CreateAttribute("fileref");
            attr.Value = FileRef;
			
			elem3.Attributes.Append( attr );
			
			elem.AppendChild( elem2 );
			elem2.AppendChild( elem3 );
			
			return elem;
		}

        public const string LocalName = "imageobject";

        public string FileRef { get; set; }
        public string Value { get; set; }
    }
}
