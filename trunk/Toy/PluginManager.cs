/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/3
 * Time: 16:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JeebookToy
{
	/// <summary>
	/// Description of PluginManager.
	/// </summary>
	public class PluginManager
	{
		string strLocate = "";
		
		public PluginManager( string strPath )
		{
			strLocate = strPath;
		}
		
		public string Find( string url ) 
		{
			Uri uri = new Uri( url );
			string[] dirs = System.IO.Directory.GetDirectories( strLocate );
			for ( int i = 0; i < dirs.Length; i ++ )
			{
				System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( dirs[i] );
				if ( 0 == string.Compare( di.Name, uri.Host, true ) )
				{
					return dirs[i];
				}
			}
			
			return "";
		}
	}
}
