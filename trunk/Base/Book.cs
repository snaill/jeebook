/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Jeebook.Base
{
	/// <summary>
	/// Description of Book.
	/// </summary>
	public class Book
	{
        public static Book Create(System.IO.Stream stream)
        {
            XDocument doc = XDocument.Load(System.Xml.XmlReader.Create(stream));
            Book book = new Book();
            book.Links = new List<ChapterLink>();

            foreach (XElement xe in doc.Root.Elements())
            {
                if (Info.LocalName == xe.Name.LocalName)
                {
                    book.Info = Info.Create(xe);
                }
                else if (ChapterLink.LocalName == xe.Name.LocalName)
                {
                    book.Links.Add(ChapterLink.Create(xe)); 
                }
                else if (MediaObject.LocalName == xe.Name.LocalName)
                {
                    book.MediaObject = MediaObject.Create(xe);
                }
            }

            return book;
        }
		
		public Info Info{ get; set;	}
        public List<ChapterLink> Links { get; set; }
        public MediaObject MediaObject { get; set; }
		
		public void Save( string strPath )
		{
            XElement root = new XElement(Namespace.Docbook + "book");
            root.SetAttributeValue("version", "5.0");
            root.SetAttributeValue(XNamespace.Xmlns + "xlink", Namespace.XLink);
            root.SetAttributeValue(XNamespace.Xmlns + "xi", Namespace.XInclude);

            if ( Info != null )
                root.Add( Info.ToXElement() );

            if (Links != null)
            {
                foreach (ChapterLink link in Links)
                    root.Add(link.ToXElement());
            }

            if (MediaObject != null)
                root.Add(MediaObject.ToXElement());

            XDocument doc = new XDocument(root);
            System.IO.StreamWriter sw = new System.IO.StreamWriter( strPath, false, System.Text.Encoding.Unicode );
            doc.Save(sw);
            sw.Close();
		}
	}
}
