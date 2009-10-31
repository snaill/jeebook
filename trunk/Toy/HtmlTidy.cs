/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 16:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;

namespace JeebookToy
{
	/// <summary>
	/// Description of HtmlTidy.
	/// </summary>
	public class HtmlTidy
	{
		public HtmlTidy()
		{
		}
		
		public static string Tidy( string str )
		{
			string strPath = System.IO.Path.GetTempFileName();
			StreamWriter sw = new StreamWriter( new FileStream(strPath, FileMode.Create ), Encoding.Unicode );
			sw.Write( str );
			sw.Close();
			
			System.Diagnostics.ProcessStartInfo  Info  =  new  System.Diagnostics.ProcessStartInfo();
			Info.FileName = System.Windows.Forms.Application.StartupPath + "\\tidy.exe";
			Info.CreateNoWindow = true;
			Info.Arguments = "-asxhtml -utf16 -m \"" + strPath + "\"";
			
			System.Diagnostics.Process	proc = System.Diagnostics.Process.Start(Info);
			proc.WaitForExit(5000);
			
			StreamReader sr = new StreamReader( new FileStream(strPath, FileMode.Open ), Encoding.Unicode );
			return sr.ReadToEnd();
		}
	}
}
