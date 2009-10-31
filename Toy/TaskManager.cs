/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 0:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using JeebookToy.JB;
using System.Collections.Specialized;

namespace JeebookToy
{
	public delegate void AddTaskHandler( Task task );
	
	/// <summary>
	/// Description of TaskManager.
	/// </summary>
	public class TaskManager : INotifyCollectionChanged
	{
		/// <summary>
		/// 未完成任务列表
		/// </summary>
		System.Collections.Generic.List<Task>	Tasks = new System.Collections.Generic.List<Task>();

		/// <summary>
		/// 任务存放根目录
		/// </summary>
		string Path;
		
		/// <summary>
		/// 任务执行线程
		/// </summary>
		Thread Loop = null;
		
		/// <summary>
		/// 任务线程执行标志
		/// </summary>
		bool bLoop = false;

		/// <summary>
		/// 任务线程执行事件
		/// </summary>
		System.Threading.AutoResetEvent LoopEvent = new AutoResetEvent(false);

		/// <summary>
		/// 列表状态变化事件
		/// </summary>
		public event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;
		
		/// <summary>
		/// 任务状态变化事件
		/// </summary>
		public event TaskStateChangedHandler TaskStateChanged;
			
		/// <summary>
		/// 构造函数，装载已创建（包括已完成）的任务
		/// </summary>
		/// <param name="strPath">任务存放根路径</param>
		public TaskManager(string strPath)
		{
			string[] dirs = System.IO.Directory.GetDirectories(strPath);
			for ( int i = 0; i < dirs.Length; i ++ )
			{
				string strTask = dirs[i] + "index.task";
				if ( System.IO.File.Exists( strTask ) )
				{
//					Task task = new Task();
//					if ( task.Load( strTask ) )
//						Add( task );
				}
				else
				{
//					Book	book = new Book(dirs[i]);
//				
//					Task task = new Task();
//				//	task.Name = book.Info.Title;
//					task.Uri = dirs[i];
//					Add( task );
				}
			}
		
			Path = strPath;
			
			//
			Loop = new Thread( new ThreadStart(LoopThread));
			Loop.Priority = ThreadPriority.Normal;
			Loop.Start();
		}
			
		/// <summary>
		/// 添加任务到任务列表
		/// </summary>
		/// <param name="task">任务对象</param>
		public void Add( Task task )
		{
			((ITaskNotify)task).TaskStateChanged += TaskStateChangedHandler;
			Tasks.Add( task );
			
			if ( CollectionChanged != null )
				CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, task ) );
		}
			
		/// <summary>
		/// 清空任务列表，并停止任务线程
		/// </summary>
		public void Clear()
		{
			bLoop = false;
			LoopEvent.WaitOne(5000);
		}
		
		void TaskStateChangedHandler( TaskStateChangedEventArgs args )
		{
			if ( TaskStateChanged != null )
				TaskStateChanged( args );
		}
		
		/// <summary>
		/// 获取某个任务的路径
		/// </summary>
		/// <param name="url">任务的URL</param>
		/// <returns>为该任务所分配的全路径名</returns>
		public string CreateTaskPath( string url )
		{
            string str = "";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] s = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(url));
            for (int i = 0; i < s.Length; i++)
            {
                str = str + s[i].ToString("x");
            }
			
            str = Path + "\\" + str;
            if ( !System.IO.Directory.Exists( str ) )
            	System.IO.Directory.CreateDirectory( str );
            return str;
		}
		
		/// <summary>
		/// 任务线程
		/// </summary>
		void LoopThread()
		{
			bLoop = true;
			while ( bLoop )
			{
				for ( int i = 0; i < Tasks.Count; i ++ )
				{
					if ( Tasks[i].State == TaskState.Finished )
						continue;
					
					Tasks[i].Run();
				}
				
				System.Threading.Thread.Sleep(1000);
			}
			
			LoopEvent.Set();
		}
	}
}
