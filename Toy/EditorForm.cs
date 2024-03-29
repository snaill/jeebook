﻿/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-10-9
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Jeebook.Base;

namespace Jeebook.Toy
{
	/// <summary>
	/// Description of EditorForm.
	/// </summary>
	public partial class EditorForm : Form
	{
        ICSharpCode.SharpZipLib.Zip.ZipFile _zf = null;
		
		public EditorForm(string fn)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
            _zf = new ICSharpCode.SharpZipLib.Zip.ZipFile(fn);

            TreeNode tn = ContentTreeView.Nodes.Add( System.IO.Path.GetFileName( fn ) );
            foreach (ICSharpCode.SharpZipLib.Zip.ZipEntry entry in _zf )
            {
                AddTreeNode( tn, entry.Name );
            }
		}

        void AddTreeNode(TreeNode tn, string path)
        {
            string[] dirs = path.Split('/');
            foreach (string dir in dirs)
            {
                TreeNode[] tns = tn.Nodes.Find(dir, false);
                tn = (null != tns) ? tn.Nodes.Add(dir) : tns[0];
            }
            tn.Tag = path;
        }

		void OpenButtonClick(object sender, EventArgs e)
		{
            //CurrentBook = Book.Create(UriTextBox.Text);
			
            //TreeNode tn = ContentTreeView.Nodes.Add(CurrentBook.Info.Title);
            //for ( int i = 0; i < CurrentBook.Chapters.Count; i ++ )
            //{
            //    TreeNode tnSub = tn.Nodes.Add( CurrentBook.Chapters[i].Title);
            //    tnSub.Tag = CurrentBook.Chapters[i];
            //}
            //tn.Expand();
		}
	
		void ContentTreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
            //if ( ContextTextBox.Tag != null )
            //{
            //    ((Element)ContextTextBox.Tag).LoadFromString( ContextTextBox.Text );
            //    ContextTextBox.Text = "";
            //}
						
            //if ( ContentTreeView.SelectedNode != ContentTreeView.TopNode )
            //{
            //    Chapter chap = (Chapter)ContentTreeView.SelectedNode.Tag;
            //    if ( chap.Elements == null )
            //    {
            //        chap = Chapter.Create( chap.Uri );
            //        ContentTreeView.SelectedNode.Tag = chap;
            //    }
				
            //    ElementsListBox.Items.Clear();
            //    ElementsListBox.Tag = chap;
            //    foreach ( Element ex in chap.Elements )
            //    {
            //        ElementsListBox.Items.Add( ex.GetLocalName() );
            //    }
            //}			
		}
		
		void ElementsListBoxSelectedIndexChanged(object sender, EventArgs e)
		{
            //if ( ContextTextBox.Tag != null )
            //    ((Element)ContextTextBox.Tag).LoadFromString( ContextTextBox.Text );
			
            //Chapter chap = (Chapter)ElementsListBox.Tag;
            //ContextTextBox.Text = chap.Elements[ElementsListBox.SelectedIndex].ToString();
            //ContextTextBox.Tag = chap.Elements[ElementsListBox.SelectedIndex];
		}
	}
}
