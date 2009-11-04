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
			
		public static Para Create(XElement xe )
		{
			Para para = new Para();
            para.Elements = new List<Element>();
            foreach (XElement elem in xe.Elements())
            {
                if (elem.GetType() == typeof(XText))
                    para.Elements.Add(Text.Create(xe));
                else if (Link.LocalName == xe.Name.LocalName)
                    para.Elements.Add(Link.Create(xe));
                else if (MediaObject.LocalName == xe.Name.LocalName)
                    para.Elements.Add(MediaObject.Create(xe));

            }
			return para;
		}

        public System.Xml.Linq.XElement ToXElement()
        {
            XElement xe = new XElement("para", "");
            foreach (Element elem in Elements)
                xe.Add(elem.ToXElement());
            return xe;
        }

		public const string     LocalName = "para";

        public List<Element> Elements { get; set; }
	}
}
