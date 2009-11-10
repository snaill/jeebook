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
	/// Description of Author.
	/// </summary>
	public class Author : Element
	{
        public Author() { }
        public Author(string otherName)
        {
            OtherName = otherName; 
        }

		public static Author Create(XElement xe)
		{
			Author author = new Author();
            author.OtherName = xe.Element(Namespace.Docbook + "personname").Element(Namespace.Docbook + "othername").Value;
			
			return author;
		}
		
		public XElement ToXElement()
		{
            return new XElement(Namespace.Docbook + LocalName,
                new XElement(Namespace.Docbook + "personname",
                    new XElement(Namespace.Docbook + "othername", OtherName)));
		}

        public const string LocalName = "author";

        public string OtherName { get; set; }
	}
}
