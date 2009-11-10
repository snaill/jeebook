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
        public Info() { }
        public Info(string title, Author author, string biblioSource)
        {
            Title = title;
            Author = author;
            BiblioSource = biblioSource;
        }

		public static Info Create( XElement xe )
		{
			Info info = new Info();
            info.Title = xe.Element(Namespace.Docbook + "title").Value;
            info.BiblioSource = xe.Element(Namespace.Docbook + "bibliosource").Value;
            info.Author = Author.Create(xe.Element(Namespace.Docbook + "author"));
			
			return info;
		}

        public XElement ToXElement()
		{
            return new XElement(Name,
                new XElement(Namespace.Docbook + "title", Title),
                Author.ToXElement(),
                new XElement(Namespace.Docbook + "bibliosource", BiblioSource));
		}

        public static XName Name = Namespace.Docbook + "info";

        public string Title { get; set; }
        public string BiblioSource { get; set; }
        public Author Author { get; set; }
	}
}
