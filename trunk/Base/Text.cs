using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jeebook.Base
{
    public class Text : Element
    {
        public static Text Create(XText xe)
        {
            string str = Text.Format(xe.Value);
            if (string.IsNullOrEmpty(str))
                return null;

            Text text = new Text();
            text.Value = str;
            return text;
        }

        public System.Xml.Linq.XElement ToXElement()
        {
            return null; // new XText(Value);
        }

        public System.Xml.Linq.XText ToXText()
        {
            return new XText(Value);
        }

        public static string Format(string str)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = str.Split('\n');
            foreach( string line in lines )
            {
                sb.Append( line.Trim("\r\t ".ToCharArray() ));
            }

            return sb.ToString();
        }

        public string Value { get; set; }
    }
}
