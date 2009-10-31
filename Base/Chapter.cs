/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Xml.Linq;

namespace Jeebook.Base
{
	/// <summary>
	/// Description of Chapter.
	/// </summary>
	public class Chapter
	{
		public Chapter()
		{
		}
		public static Chapter Create(string strFilename)
		{
			Chapter chap = new Chapter();
			XDocument doc = XDocument.Load( strFilename );
			chap.Title = doc.Root.Element("title").Value;
			chap.Uri = strFilename;
			chap.Elements = new System.Collections.Generic.List<Element>();
			foreach ( XElement elem in doc.Root.Elements() )
			{
				if ( Para.Xml_LocalName == elem.Name )
					chap.Elements.Add( Para.Create( elem ) );
			}
			return chap;
		}
		
		public string Title = "New Chapter";
		public string Uri = "";
		public System.Collections.Generic.List<Element>	Elements = null;
	}
}
