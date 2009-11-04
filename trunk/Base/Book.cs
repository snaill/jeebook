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
            XNamespace nsDocbook = "http://docbook.org/ns/docbook";
            XNamespace nsXLink = "http://www.w3.org/1999/xlink";
            XNamespace nsXInclude = "http://www.w3.org/2001/XInclude";

            XElement root = new XElement(nsDocbook + "book");
            root.SetAttributeValue("version", "5.0");
            root.SetAttributeValue(XNamespace.Xmlns + "xlink", nsXLink);
            root.SetAttributeValue(XNamespace.Xmlns + "xi", nsXInclude);

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
            doc.Save(strPath);
		}
	}
}
