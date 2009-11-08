/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Linq;

namespace Jeebook.Base
{
	/// <summary>
	/// Description of Link.
	/// </summary>
	public class Link : Element
	{
		public Link() {	}
        public Link( string href, string value ) 
        {
            Href = href;
            Value = value;        
        }

        public static Link Create(XElement xe)
        {
            Link link = new Link();
            link.Href = xe.Attribute(Namespace.XLink + "href").Value;
            link.Value = xe.Value;
            return link;
        }

		public string Href { get; set; }
		public string Value { get; set; }

        public XElement ToXElement()
        {
            return new XElement( LocalName, new XAttribute( Namespace.XLink + "href", Href ), Value );
        }

        public const string LocalName = "link";
	}
}
