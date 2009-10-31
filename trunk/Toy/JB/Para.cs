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

namespace JeebookToy.JB
{
	/// <summary>
	/// Description of Para.
	/// </summary>
	public class Para : Element
	{
		public Para()
		{
		}
			
		public string GetLocalName()	{ return "para";}

		public static Para Create(XElement xe )
		{
			Para para = new Para();
			para.Text = xe.Value;
			return para;
		}
		
		public void LoadFromString(string str )
		{
			Text = str;
		}
		
		public override string ToString() 
		{
			return Text;
		}
		public const string Xml_LocalName = "para";
		public string Text;
	}
}
