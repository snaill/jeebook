/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Jeebook.Base
{
	/// <summary>
	/// Description of Para.
	/// </summary>
	public class Para : Element
	{
		public Para() {	}
        public Para(string str) 
        {
            this.Elements = new List<Element>();
            this.Elements.Add(new Text(str));
        }
			
		public static Para Create(XElement xe )
		{
			Para para = new Para();
            para.Elements = new List<Element>();
            foreach (XNode node in xe.Nodes())
            {
                if (node.NodeType == System.Xml.XmlNodeType.Text)
                {
                    Text text = Text.Create(node as XText);
                    if ( null != text )
                        para.Elements.Add(text);
                }
                else
                {
                    XElement elem = node as XElement;
                    if (elem == null)
                        continue;

                    if (Link.LocalName == elem.Name.LocalName)
                        para.Elements.Add(Link.Create(elem));
                    else if (MediaObject.LocalName == elem.Name.LocalName)
                        para.Elements.Add(MediaObject.Create(elem));
                }

            }
			return para;
		}

        public System.Xml.Linq.XElement ToXElement()
        {
            XElement xe = new XElement(Namespace.Docbook + "para", "");
            foreach (Element elem in Elements)
            {
                if (elem.GetType() == typeof(Text))
                    xe.Add((elem as Text).ToXText());
                else
                    xe.Add(elem.ToXElement());
            }
            return xe;
        }

		public const string     LocalName = "para";

        public List<Element> Elements { get; set; }
	}
}
