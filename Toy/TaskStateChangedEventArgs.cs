/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/5
 * Time: 16:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Jeebook.Toy
{
	/// <summary>
	/// Description of TaskStateChangedEventArgs.
	/// </summary>
	public class TaskStateChangedEventArgs : EventArgs
	{
		/// <summary>
		/// 当前任务
		/// </summary>
		public Task	Current = null;
		
		/// <summary>
		/// 当前正在处理的资源
		/// </summary>
		public string CurrentUri = "";
		
		/// <summary>
		/// 需要处理的文件数
		/// </summary>
		public int TotalCount = 1;
		
		/// <summary>
		/// 已处理完的文件数
		/// </summary>
		public int FinishedCount = 0;
		
		/// <summary>
		/// 错误信息
		/// </summary>
		public string ErrorMassage = "Success";
		
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="task">当前任务</param>
		public TaskStateChangedEventArgs( Task task )
		{
			Current = task;
		}
		
		/// <summary>
		/// ToString函数
		/// </summary>
		/// <returns>该事件的信息字符串</returns>
		public new string ToString()	
		{
			if ( Current == null )
				return "";
			
			switch ( Current.State )
			{
			case TaskState.Ready: return "Ready";
			case TaskState.Finished: return "Finished";
			case TaskState.Packaging: return "Packaging ...";
            case TaskState.Analysing: return "Analysing...";
			case TaskState.Failed: return "Failed : " + ErrorMassage; 
			case TaskState.Downloading:
                return string.Format("[{0}/{1}] Downloading : {2}", FinishedCount, TotalCount, CurrentUri);
			case TaskState.ToXHtml:
                return string.Format("[{0}/{1}] Convert to XHTML : {2}", FinishedCount, TotalCount, CurrentUri);
			case TaskState.ToJeebook:
                return string.Format("[{0}/{1}] Creating Jeebook XML : {2}", FinishedCount, TotalCount, CurrentUri);
			default:
				System.Diagnostics.Debug.Assert( false );
				return "";
			}
		}
	}
}
