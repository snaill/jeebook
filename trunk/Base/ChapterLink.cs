using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jeebook.Base
{
    public class ChapterLink
    {
        public static ChapterLink Create(XElement xe)
        {
            ChapterLink cl = new ChapterLink();
            cl.Href = xe.Attribute("href").Value;
            cl.Value = xe.Value;

            return cl;
        }

        public const string LocalName = "include";
        public string Href { get; set; }
        public string Value { get; set; }
    }
}
