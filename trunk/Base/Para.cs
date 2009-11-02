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

namespace Jeebook.Base
{
	/// <summary>
	/// Description of Para.
	/// </summary>
	public class Para
	{
		public Para() {	}
        public Para(string text) 
        { 
            Text = text; 
        }
			
		public string GetLocalName()	{ return "para";}

		public static Para Create(XElement xe )
		{
			Para para = new Para();
			para.Text = xe.Value;
			return para;
		}
		
		public const string LocalName = "para";
		public string Text;
	}
}
