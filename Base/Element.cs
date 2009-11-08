/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Linq;

namespace Jeebook.Base
{
    public class Namespace
    {
         public static XNamespace Docbook = "http://docbook.org/ns/docbook";
         public static XNamespace XLink = "http://www.w3.org/1999/xlink";
         public static XNamespace XInclude = "http://www.w3.org/2001/XInclude";
    }

	/// <summary>
	/// Description of Element.
	/// </summary>
	public interface Element
	{
        System.Xml.Linq.XElement ToXElement();
	}
}
