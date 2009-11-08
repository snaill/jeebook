/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-25
 * Time: 16:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Jeebook.Toy
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TaskListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.TaskStateImageList = new System.Windows.Forms.ImageList(this.components);
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.AddFromBookUrlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFromComicFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFromTextFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UrlTextBox = new JeebookToy.Controls.ToolStripSpringTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TesterToolButton = new System.Windows.Forms.ToolStripButton();
            this.EditorToolButton = new System.Windows.Forms.ToolStripButton();
            this.MainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskListView
            // 
            this.TaskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.TaskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskListView.FullRowSelect = true;
            this.TaskListView.Location = new System.Drawing.Point(0, 39);
            this.TaskListView.Name = "TaskListView";
            this.TaskListView.Size = new System.Drawing.Size(419, 233);
            this.TaskListView.SmallImageList = this.TaskStateImageList;
            this.TaskListView.TabIndex = 0;
            this.TaskListView.UseCompatibleStateImageBehavior = false;
            this.TaskListView.View = System.Windows.Forms.View.Details;
            this.TaskListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaskListView_DragDrop);
            this.TaskListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.TaskListView_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 250;
            // 
            // TaskStateImageList
            // 
            this.TaskStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TaskStateImageList.ImageStream")));
            this.TaskStateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TaskStateImageList.Images.SetKeyName(0, "Finished");
            this.TaskStateImageList.Images.SetKeyName(1, "Failed");
            this.TaskStateImageList.Images.SetKeyName(2, "Packaging");
            this.TaskStateImageList.Images.SetKeyName(3, "Downloading");
            this.TaskStateImageList.Images.SetKeyName(4, "ToXHtml");
            this.TaskStateImageList.Images.SetKeyName(5, "ToJeebook");
            this.TaskStateImageList.Images.SetKeyName(6, "Ready");
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 272);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(419, 22);
            this.StatusStrip.TabIndex = 3;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.UrlTextBox,
            this.toolStripSeparator1,
            this.TesterToolButton,
            this.EditorToolButton});
            this.MainToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(419, 39);
            this.MainToolStrip.TabIndex = 6;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFromBookUrlMenuItem,
            this.AddFromComicFolderMenuItem,
            this.AddFromTextFileMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 36);
            this.toolStripDropDownButton1.ToolTipText = "AddToolStripDropDownButton";
            // 
            // AddFromBookUrlMenuItem
            // 
            this.AddFromBookUrlMenuItem.Name = "AddFromBookUrlMenuItem";
            this.AddFromBookUrlMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddFromBookUrlMenuItem.Text = "Book Url";
            this.AddFromBookUrlMenuItem.Click += new System.EventHandler(this.AddFromBookUrlMenuItem_Click);
            // 
            // AddFromComicFolderMenuItem
            // 
            this.AddFromComicFolderMenuItem.Name = "AddFromComicFolderMenuItem";
            this.AddFromComicFolderMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddFromComicFolderMenuItem.Text = "Comic Folder";
            this.AddFromComicFolderMenuItem.Click += new System.EventHandler(this.AddFromComicFolderMenuItem_Click);
            // 
            // AddFromTextFileMenuItem
            // 
            this.AddFromTextFileMenuItem.Name = "AddFromTextFileMenuItem";
            this.AddFromTextFileMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddFromTextFileMenuItem.Text = "Text File";
            this.AddFromTextFileMenuItem.Click += new System.EventHandler(this.AddFromTextFileMenuItem_Click);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(262, 39);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // TesterToolButton
            // 
            this.TesterToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TesterToolButton.Image = ((System.Drawing.Image)(resources.GetObject("TesterToolButton.Image")));
            this.TesterToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TesterToolButton.Name = "TesterToolButton";
            this.TesterToolButton.Size = new System.Drawing.Size(36, 36);
            this.TesterToolButton.Text = "Xslt Tester";
            this.TesterToolButton.ToolTipText = "Xslt Tester";
            this.TesterToolButton.Click += new System.EventHandler(this.PluginTestMenuItemClick);
            // 
            // EditorToolButton
            // 
            this.EditorToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditorToolButton.Image = ((System.Drawing.Image)(resources.GetObject("EditorToolButton.Image")));
            this.EditorToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditorToolButton.Name = "EditorToolButton";
            this.EditorToolButton.Size = new System.Drawing.Size(36, 36);
            this.EditorToolButton.Text = "Jeebook Editor";
            this.EditorToolButton.Click += new System.EventHandler(this.EditorMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 294);
            this.Controls.Add(this.TaskListView);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.StatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "JeebookToy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripButton EditorToolButton;
		private System.Windows.Forms.ToolStripButton TesterToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ImageList TaskStateImageList;
		private System.Windows.Forms.ListView TaskListView;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip MainToolStrip; 
        private System.Windows.Forms.StatusStrip StatusStrip;
		private JeebookToy.Controls.ToolStripSpringTextBox UrlTextBox;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem AddFromComicFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddFromBookUrlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddFromTextFileMenuItem;
	}
}
