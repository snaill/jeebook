using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jeebook.Base
{
    public class ChapterLink
    {
        public ChapterLink() { }
        public ChapterLink( string href, string value)
        {
            Href = href;
            Value = value;
        }

        public static ChapterLink Create(XElement xe)
        {
            ChapterLink cl = new ChapterLink();
            cl.Href = xe.Attribute("href").Value;
            cl.Value = xe.Value;

            return cl;
        }

        public XElement ToXElement()
        {
            return new XElement(Name, new XAttribute("href", Href), Value);
        }

        public static XName Name = Namespace.XInclude + "include";

        public string Href { get; set; }
        public string Value { get; set; }
    }
}
