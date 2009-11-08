/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-25
 * Time: 16:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Specialized;
using JeebookToy.Controls;

namespace Jeebook.Toy
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		TaskManager 	_TManager = new TaskManager(System.Windows.Forms.Application.StartupPath + "\\temp\\");
		PluginManager	_PManager = new PluginManager(System.Windows.Forms.Application.StartupPath + "\\plugins\\");
        string          _JBPath = "";

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			Xsl2Engine.CurrentEngine = Xsl2Engine.CheckEngine();
			
			_TManager.TaskStateChanged += TaskStateChangedHandler;
			_TManager.CollectionChanged += CollectionChangedHandler;

            //
            string str = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!str.EndsWith("\\"))
                str += "\\";
            _JBPath += str + "Jeebooks";
            if (System.IO.Directory.Exists(_JBPath))
                System.IO.Directory.CreateDirectory(_JBPath);
		}
		
		void CollectionChangedHandler( object sender, NotifyCollectionChangedEventArgs args )
		{
			if ( args.Action == NotifyCollectionChangedAction.Add )
			{
				Task task = (Task)args.NewItems[0];
				ListViewItem lvi = TaskListView.Items.Add( task.Name );
				lvi.SubItems.Add("Ready");
				lvi.Tag = task;
			}
		}
		
		
		void TaskStateChangedHandler( TaskStateChangedEventArgs args )
		{
			TaskListView.Invoke( new TaskStateChangedHandler(TaskStateChanged), new object[1]{args} );
		}
		
		void TaskStateChanged( TaskStateChangedEventArgs args )
		{
			//
			ListViewItem item = null;
			for ( int i = 0; i < TaskListView.Items.Count; i ++ )
			{
				if ( TaskListView.Items[i].Tag == args.Current )
				{
					item = TaskListView.Items[i];
					break;
				}
			}
			System.Diagnostics.Debug.Assert( item != null );

			//
			switch ( args.Current.State )
			{
				case TaskState.Downloading: item.ImageKey = "Downloading"; break;
				case TaskState.Finished: item.ImageKey = "Finished"; break;
				case TaskState.Failed: item.ImageKey = "Failed"; break;
				case TaskState.Packaging: item.ImageKey = "Packaging";break;
				case TaskState.Ready: item.ImageKey = "Ready";break;
				case TaskState.ToJeebook: item.ImageKey = "ToJeebook";break;
				case TaskState.ToXHtml: item.ImageKey = "ToXHtml";break;
			}
			item.Text = args.Current.Name;
			item.SubItems[1].Text = args.ToString();
		}
		
		void PluginTestMenuItemClick(object sender, EventArgs e)
		{
			TesterForm form = new TesterForm();
			form.Show();
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
            _TManager.Clear();
		}
		
		void EditorMenuItemClick(object sender, EventArgs e)
		{
			EditorForm form = new EditorForm();
			form.Show();
		}

        void AddTask(string uri, TaskSource source)
        {
            Task task = null;
            switch (source)
            {
                case TaskSource.BookUrl:
                    {
                        string strPlugin = _PManager.Find(UrlTextBox.Text);
                        if (strPlugin == "")
                        {
                            MessageBox.Show("Unknown website");
                            return;
                        }

                        task = new BookTask(uri, strPlugin, _TManager.CreateTaskPath(uri), System.Windows.Forms.Application.StartupPath + "\\JBs\\");
                        break;
                    }
                case TaskSource.ComicFolder:
                    {
                        task = new ComicTask(UrlTextBox.Text, System.Windows.Forms.Application.StartupPath + "\\JBs\\");
                        break;
                    }
                case TaskSource.TextFile:
                    task = new TextTask(UrlTextBox.Text, System.Windows.Forms.Application.StartupPath + "\\JBs\\"); 
                    break;
                default:
                    return;
            }

            if (task != null)
                _TManager.Add(task);
        }

        private void AddFromBookUrlMenuItem_Click(object sender, EventArgs e)
        {
            AddTask(UrlTextBox.Text, TaskSource.BookUrl);
        }

        private void AddFromComicFolderMenuItem_Click(object sender, EventArgs e)
        {
            AddTask(UrlTextBox.Text, TaskSource.ComicFolder);
        }

        private void AddFromTextFileMenuItem_Click(object sender, EventArgs e)
        {
            AddTask(UrlTextBox.Text, TaskSource.TextFile);
        }

        private void TaskListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None; 
        }

        private void TaskListView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                foreach (object o in (System.Array)e.Data.GetData(DataFormats.FileDrop))
                {
                    string strFile = o.ToString();
                    System.IO.FileInfo fi = new System.IO.FileInfo( strFile );
                    if ( ( fi.Attributes & System.IO.FileAttributes.Directory ) == System.IO.FileAttributes.Directory )
                    {
                        AddTask( strFile, TaskSource.ComicFolder );
                    }
                    else if (fi.Extension.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        AddTask(strFile, TaskSource.TextFile);
                    }
                }
            }
            catch
            {

            }
        }

	}
}
