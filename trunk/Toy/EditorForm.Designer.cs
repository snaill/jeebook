/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-10-9
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Jeebook.Toy
{
	partial class EditorForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ContentTreeView = new System.Windows.Forms.TreeView();
            this.ContextTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ContentTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ContextTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(373, 288);
            this.splitContainer1.SplitterDistance = 141;
            this.splitContainer1.TabIndex = 1;
            // 
            // ContentTreeView
            // 
            this.ContentTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentTreeView.Location = new System.Drawing.Point(0, 0);
            this.ContentTreeView.Name = "ContentTreeView";
            this.ContentTreeView.Size = new System.Drawing.Size(141, 288);
            this.ContentTreeView.TabIndex = 0;
            this.ContentTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ContentTreeViewAfterSelect);
            // 
            // ContextTextBox
            // 
            this.ContextTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContextTextBox.Location = new System.Drawing.Point(0, 0);
            this.ContextTextBox.Multiline = true;
            this.ContextTextBox.Name = "ContextTextBox";
            this.ContextTextBox.Size = new System.Drawing.Size(228, 288);
            this.ContextTextBox.TabIndex = 0;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 288);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		private System.Windows.Forms.TextBox ContextTextBox;
        private System.Windows.Forms.TreeView ContentTreeView;
        private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
