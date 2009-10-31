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

namespace JeebookToy.JB
{
	/// <summary>
	/// Description of Book.
	/// </summary>
	public class Book
	{
		public Book() {}
		
		public static Book Create(string strPath)
		{
			Book book = new Book();
			XDocument doc = XDocument.Load( strPath + "\\index.xml" );
			book.Info = Info.Create( doc.Root.Element("info") );
			
			var chaps = from cNode in doc.Root.Elements(XName.Get("include", "http://www.w3.org/2001/XInclude"))
				select new Chapter 
				{
					Title = cNode.Value,
					Uri = cNode.Attribute("href").Value
				};
			
			foreach( Chapter c in chaps )
			{
				c.Uri = strPath + "\\" + c.Uri;
				book.Chapters.Add( c );
			}
			
			book.Path = strPath;
			return book;
		}
		
		public Info Info{ get; set;	}
		public string Path;
		public System.Collections.Generic.List<Chapter>	Chapters = new System.Collections.Generic.List<Chapter>();
		
		public void Save( string strPath )
		{
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

			System.Xml.XmlNamespaceManager xnm = new System.Xml.XmlNamespaceManager(doc.NameTable);
			xnm.AddNamespace("", "http://docbook.org/ns/docbook");
			xnm.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
			xnm.AddNamespace("xi", "http://www.w3.org/2001/XInclude");
			
			if ( Info != null )
			{
				System.Xml.XmlElement elem = Info.ToXmlElement(doc);
				if ( elem != null )
					doc.AppendChild( elem );
			}
			
			foreach ( Chapter chap in Chapters )
			{
				//chap.Save();
			}
		}
	}
}
