/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 0:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Altova.AltovaXML;

namespace Jeebook.Toy
{
	public delegate void TaskStateChangedHandler( TaskStateChangedEventArgs args );

    public enum TaskSource
    {
        BookUrl,
        ComicFolder,
        TextFile
    }

	public enum TaskState 
	{
		Ready,
		Downloading,
        Analysing,
		ToXHtml,
		ToJeebook,
		Packaging,
		Finished,
		Failed
	}
	
	public interface ITaskNotify
	{
		/// <summary>
		/// 任务状态变化事件
		/// </summary>
		event TaskStateChangedHandler TaskStateChanged;		
	}
	
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{
		/// <summary>
		/// 任务名，也是图书名称，对应Book/Info/Title
		/// </summary>
		public string Name = "New Task";
		
		/// <summary>
		/// 下载的起始路径，对应Book/Info/bibliosource
		/// </summary>
		public string Uri = "";
		
		/// <summary>
		/// 任务状态
		/// </summary>
		public TaskState State = TaskState.Ready;
		
		/// <summary>
		/// 目标文件（打包后文件）路径
		/// </summary>
		public string JBPath = "";

		protected Task()
		{
            Name = "New Task";
            State = TaskState.Ready;
        }

		public bool Load(string strPath)
		{
			return false;
		}
		
		public void Save(string strPath)
		{
			
		}
		
		public virtual void Run()
		{
			// 下载目录页
			// 格式化处理HtmlTidy
			// 解析章节列表Xsl
			// 循环
				// 下载章节页
				// 格式化处理HtmlTidy
				// 解析章节内容Xsl
		}
		
		public static string Download( string strURL )
		{
			try 
			{
				System.Net.WebRequest request = System.Net.WebRequest.Create( strURL );
				System.Net.WebResponse response = request.GetResponse();
				System.IO.StreamReader stream = new System.IO.StreamReader( response.GetResponseStream(), System.Text.Encoding.Default );
				string strInput = stream.ReadToEnd();

				response.Close();
				stream.Close(); 
				return strInput;
			} 
			catch ( Exception ) 
			{
				return "";
			}
		}
		
		public static string Html2XHtml( string strHtml )
		{
			TidyNet.Tidy tidy = new TidyNet.Tidy();

            /* Set the options you want */
            tidy.Options.Xhtml = true;
            tidy.Options.XmlOut = true;
            tidy.Options.MakeClean = true;
            tidy.Options.CharEncoding = TidyNet.CharEncoding.UTF8;

            /* Declare the parameters that is needed */
            System.IO.MemoryStream input = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(strHtml));
            System.IO.MemoryStream output = new System.IO.MemoryStream();
            tidy.Parse(input, output, new TidyNet.TidyMessageCollection());

            return System.Text.Encoding.UTF8.GetString(output.ToArray());
		}
		
		public static string Transform(string strXml, string strXslFile )
		{
			System.IO.TextReader input = new System.IO.StreamReader(strXslFile);
			string strXsl = input.ReadToEnd();
			input.Close();
			
			return Xsl2Engine.Transform( strXml, strXsl );
		}
		
		public static void Transform(string strXml, string strOutput, string strXslFile )
		{
			System.IO.TextReader input = new System.IO.StreamReader(strXslFile);
			string strXsl = input.ReadToEnd();
			input.Close();
			
			string result = Xsl2Engine.Transform( strXml, strXsl );
			
			System.IO.TextWriter tw = new System.IO.StreamWriter( strOutput, false, System.Text.Encoding.Unicode );
			tw.Write( result );
			tw.Close();
		}	
		
		public static string GetPath( string url, string strPath )
		{
			if ( strPath.Contains("://") )
				return strPath;
			          
			Uri uri = new Uri(new Uri(url), strPath );
			return uri.AbsoluteUri;
		}
	}
}
