/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:30
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
	/// Description of Chapter.
	/// </summary>
	public class Chapter
	{
        public static Chapter Create(System.IO.Stream stream)
        {
            XDocument doc = XDocument.Load(System.Xml.XmlReader.Create(stream));
            Chapter chap = new Chapter();
            chap.Paras = new List<Para>();

            foreach (XElement xe in doc.Root.Elements())
            {
                if (Para.LocalName == xe.Name.LocalName)
                {
                    chap.Paras.Add( Para.Create( xe ));
                }
                else if ("title" == xe.Name.LocalName)
                {
                    chap.Title = xe.Value;
                }
                else if (MediaObject.LocalName == xe.Name.LocalName)
                {
                    chap.MediaObject = MediaObject.Create(xe);
                }
            }

            return chap;
        }

        public string Title = "";
        public List<Para> Paras = null;
        public MediaObject MediaObject { get; set; }

        public void Save(string strPath)
        {
            XNamespace nsDocbook = "http://docbook.org/ns/docbook";
            XNamespace nsXLink = "http://www.w3.org/1999/xlink";
            XNamespace nsXInclude = "http://www.w3.org/2001/XInclude";

            XElement root = new XElement(nsDocbook + "chapter");
            root.SetAttributeValue("version", "5.0");
            root.SetAttributeValue(XNamespace.Xmlns + "xlink", nsXLink);
            root.SetAttributeValue(XNamespace.Xmlns + "xi", nsXInclude);

            root.Add(new XElement("title", Title));

            if (Paras != null)
            {
                foreach (Para para in Paras)
                    root.Add(para.ToXElement());
            }

            if (MediaObject != null)
                root.Add(MediaObject.ToXElement());

            XDocument doc = new XDocument(root);
            doc.Save(strPath);
        }
	}
}
