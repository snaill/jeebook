/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-10-9
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace JeebookToy
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.UriTextBox = new System.Windows.Forms.TextBox();
			this.OpenButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.ContentTreeView = new System.Windows.Forms.TreeView();
			this.ElementsListBox = new System.Windows.Forms.ListBox();
			this.ContextTextBox = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.UriTextBox);
			this.flowLayoutPanel1.Controls.Add(this.OpenButton);
			this.flowLayoutPanel1.Controls.Add(this.SaveButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(373, 35);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// UriTextBox
			// 
			this.UriTextBox.Location = new System.Drawing.Point(3, 3);
			this.UriTextBox.Name = "UriTextBox";
			this.UriTextBox.Size = new System.Drawing.Size(201, 20);
			this.UriTextBox.TabIndex = 0;
			// 
			// OpenButton
			// 
			this.OpenButton.Location = new System.Drawing.Point(210, 3);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(75, 25);
			this.OpenButton.TabIndex = 1;
			this.OpenButton.Text = "Open";
			this.OpenButton.UseVisualStyleBackColor = true;
			this.OpenButton.Click += new System.EventHandler(this.OpenButtonClick);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(291, 3);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 35);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.ContextTextBox);
			this.splitContainer1.Size = new System.Drawing.Size(373, 253);
			this.splitContainer1.SplitterDistance = 224;
			this.splitContainer1.TabIndex = 1;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.ContentTreeView);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.ElementsListBox);
			this.splitContainer2.Size = new System.Drawing.Size(224, 253);
			this.splitContainer2.SplitterDistance = 118;
			this.splitContainer2.TabIndex = 1;
			// 
			// ContentTreeView
			// 
			this.ContentTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContentTreeView.Location = new System.Drawing.Point(0, 0);
			this.ContentTreeView.Name = "ContentTreeView";
			this.ContentTreeView.Size = new System.Drawing.Size(118, 253);
			this.ContentTreeView.TabIndex = 0;
			this.ContentTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ContentTreeViewAfterSelect);
			// 
			// ElementsListBox
			// 
			this.ElementsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ElementsListBox.FormattingEnabled = true;
			this.ElementsListBox.Location = new System.Drawing.Point(0, 0);
			this.ElementsListBox.Name = "ElementsListBox";
			this.ElementsListBox.Size = new System.Drawing.Size(102, 251);
			this.ElementsListBox.TabIndex = 0;
			this.ElementsListBox.SelectedIndexChanged += new System.EventHandler(this.ElementsListBoxSelectedIndexChanged);
			// 
			// ContextTextBox
			// 
			this.ContextTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContextTextBox.Location = new System.Drawing.Point(0, 0);
			this.ContextTextBox.Multiline = true;
			this.ContextTextBox.Name = "ContextTextBox";
			this.ContextTextBox.Size = new System.Drawing.Size(145, 253);
			this.ContextTextBox.TabIndex = 0;
			// 
			// EditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 288);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "EditorForm";
			this.Text = "EditorForm";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.ListBox ElementsListBox;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TextBox ContextTextBox;
		private System.Windows.Forms.TreeView ContentTreeView;
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.TextBox UriTextBox;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}
