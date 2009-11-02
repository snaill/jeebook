/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/2
 * Time: 20:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Jeebook.Base;

namespace Jeebook.Toy
{
	/// <summary>
	/// Description of BookTask.
	/// </summary>
	public class BookTask : Task, ITaskNotify
	{
		public event TaskStateChangedHandler TaskStateChanged;

        /// <summary>
        /// 执行该任务所需要的插件路径
        /// </summary>
        public string XsltPath = "";

        /// <summary>
        /// 暂存临时文件（等待打包文件）的路径
        /// </summary>
        public string XmlPath = "";

        public void Create(string uri, string strXsltPath, string strXmlPath, string strJBPath)
        {
            XsltPath = strXsltPath;
            XmlPath = strXmlPath;
            base.Create(uri, strJBPath);
        }

		public override void  Run()
		{
			TaskStateChangedEventArgs args = new TaskStateChangedEventArgs(this);
			args.Url = this.Uri;
			State = TaskState.Downloading;
			if ( TaskStateChanged != null )
				TaskStateChanged( args );
			
			// 下载目录页
			string index = Download( Uri );
			
			//
			State = TaskState.ToXHtml;
			if ( TaskStateChanged != null )
				TaskStateChanged( args );
			
			// 格式化处理HtmlTidy
			index = Html2XHtml( index );
	
			//
			State = TaskState.ToJeebook;
			if ( TaskStateChanged != null )
				TaskStateChanged( args );
			
			// 解析章节列表Xsl
			Transform( index, XmlPath + "\\index.xml", XsltPath + "\\index.xslt" );
			
			// 整理图书信息，并获取目录列表
//			Book book = new Book(XmlPath);
//			if ( book.Info.Title == "" )
//				book.Info.Title = "Unkown Title";
//			book.Info.BiblioSource = Uri;
//			book.Save(XmlPath + "\\index.xml");
			
			// 循环
//			for ( int i = 0; i < book.Chapters.Count; i ++ )
//			{
//				// 下载章节页
//				// 格式化处理HtmlTidy
//				// 解析章节内容Xsl
//			}
			
			//
			State = TaskState.Finished;
			if ( TaskStateChanged != null )
				TaskStateChanged( args );
		}
	}
}
