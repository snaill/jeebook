/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Linq;

namespace Jeebook.Base
{
	/// <summary>
	/// Description of Info.
	/// </summary>
	public class Info : Element
	{
		public static Info Create( XElement xe )
		{
			Info info = new Info();
			info.Title = xe.Element("title").Value;
			info.BiblioSource = xe.Element("bibliosource").Value;
			info.Author = Author.Create( xe.Element("author") );
			
			return info;
		}

        public XElement ToXElement()
		{
            return new XElement(LocalName,
                new XElement("title", Title),
                Author.ToXElement(),
                new XElement("bibliosource", BiblioSource));
		}

        public const string LocalName = "info";

        public string Title { get; set; }
        public string BiblioSource { get; set; }
        public Author Author { get; set; }
	}
}
