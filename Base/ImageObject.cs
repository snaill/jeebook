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
        public ImageObject() { }
        public ImageObject(string fileRef, string value)
        {
            FileRef = fileRef;
            Value = value;
        }

        public static ImageObject Create(XElement xe)
        {
            ImageObject io = new ImageObject();

            XElement elem = xe.Element("imagedata");
            io.FileRef = elem.Attribute("fileref").Value;
            io.Value = elem.Value;

            return io;
        }

		public XElement ToXElement()
		{
            return new XElement( LocalName, 
                new XElement( "imagedata", 
                    new XAttribute( "fileref", FileRef ), Value ) );

		}

        public const string LocalName = "imageobject";

        public string FileRef { get; set; }
        public string Value { get; set; }
    }
}
