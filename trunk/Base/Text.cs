using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jeebook.Base
{
    class Text : Element
    {
        public static Text Create(XElement xe)
        {
            Text text = new Text();
            text.Value = xe.Value;
            return text;
        }

        public System.Xml.Linq.XElement ToXElement()
        {
            return null; // new XText(Value);
        }

        public string Value { get; set; }
    }
}
