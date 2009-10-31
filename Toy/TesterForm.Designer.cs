/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace JeebookToy
{
	partial class TesterForm
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
			this.PluginsComboBox = new System.Windows.Forms.ComboBox();
			this.XslComboBox = new System.Windows.Forms.ComboBox();
			this.SourceTextBox = new System.Windows.Forms.TextBox();
			this.TargetTextBox = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.XHtmlTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.CreateButton = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.CharacterStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.XHtmlStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.JBXmlStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PluginsComboBox
			// 
			this.PluginsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PluginsComboBox.FormattingEnabled = true;
			this.PluginsComboBox.Location = new System.Drawing.Point(3, 3);
			this.PluginsComboBox.Name = "PluginsComboBox";
			this.PluginsComboBox.Size = new System.Drawing.Size(234, 21);
			this.PluginsComboBox.TabIndex = 0;
			this.PluginsComboBox.SelectedIndexChanged += new System.EventHandler(this.PluginsComboBoxSelectedIndexChanged);
			// 
			// XslComboBox
			// 
			this.XslComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.XslComboBox.FormattingEnabled = true;
			this.XslComboBox.Location = new System.Drawing.Point(243, 3);
			this.XslComboBox.Name = "XslComboBox";
			this.XslComboBox.Size = new System.Drawing.Size(121, 21);
			this.XslComboBox.TabIndex = 1;
			// 
			// SourceTextBox
			// 
			this.SourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SourceTextBox.Location = new System.Drawing.Point(0, 23);
			this.SourceTextBox.Multiline = true;
			this.SourceTextBox.Name = "SourceTextBox";
			this.SourceTextBox.Size = new System.Drawing.Size(132, 221);
			this.SourceTextBox.TabIndex = 2;
			this.SourceTextBox.DoubleClick += new System.EventHandler(this.SourceTextBoxDoubleClick);
			// 
			// TargetTextBox
			// 
			this.TargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TargetTextBox.Location = new System.Drawing.Point(0, 23);
			this.TargetTextBox.Multiline = true;
			this.TargetTextBox.Name = "TargetTextBox";
			this.TargetTextBox.ReadOnly = true;
			this.TargetTextBox.Size = new System.Drawing.Size(166, 221);
			this.TargetTextBox.TabIndex = 3;
			this.TargetTextBox.DoubleClick += new System.EventHandler(this.TargetTextBoxDoubleClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 32);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.SourceTextBox);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(459, 244);
			this.splitContainer1.SplitterDistance = 132;
			this.splitContainer1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "HTML";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.XHtmlTextBox);
			this.splitContainer2.Panel1.Controls.Add(this.label2);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.TargetTextBox);
			this.splitContainer2.Panel2.Controls.Add(this.label3);
			this.splitContainer2.Size = new System.Drawing.Size(323, 244);
			this.splitContainer2.SplitterDistance = 153;
			this.splitContainer2.TabIndex = 4;
			// 
			// XHtmlTextBox
			// 
			this.XHtmlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.XHtmlTextBox.Location = new System.Drawing.Point(0, 23);
			this.XHtmlTextBox.Multiline = true;
			this.XHtmlTextBox.Name = "XHtmlTextBox";
			this.XHtmlTextBox.ReadOnly = true;
			this.XHtmlTextBox.Size = new System.Drawing.Size(153, 221);
			this.XHtmlTextBox.TabIndex = 0;
			this.XHtmlTextBox.DoubleClick += new System.EventHandler(this.XHtmlTextBoxDoubleClick);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(153, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "XHTML";
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(166, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "JeeBook XML";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.PluginsComboBox);
			this.flowLayoutPanel1.Controls.Add(this.XslComboBox);
			this.flowLayoutPanel1.Controls.Add(this.CreateButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(459, 32);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// CreateButton
			// 
			this.CreateButton.Location = new System.Drawing.Point(370, 3);
			this.CreateButton.Name = "CreateButton";
			this.CreateButton.Size = new System.Drawing.Size(75, 23);
			this.CreateButton.TabIndex = 0;
			this.CreateButton.Text = "Create";
			this.CreateButton.UseVisualStyleBackColor = true;
			this.CreateButton.Click += new System.EventHandler(this.CreateButtonClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1,
									this.CharacterStatusLabel,
									this.XHtmlStatusLabel,
									this.JBXmlStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 276);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(459, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "StatusStrip";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
			this.toolStripStatusLabel1.Text = "Result :";
			// 
			// CharacterStatusLabel
			// 
			this.CharacterStatusLabel.Name = "CharacterStatusLabel";
			this.CharacterStatusLabel.Size = new System.Drawing.Size(65, 17);
			this.CharacterStatusLabel.Text = "0 character";
			// 
			// XHtmlStatusLabel
			// 
			this.XHtmlStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.XHtmlStatusLabel.Name = "XHtmlStatusLabel";
			this.XHtmlStatusLabel.Size = new System.Drawing.Size(83, 17);
			this.XHtmlStatusLabel.Text = "[XHTML] 0 ms";
			this.XHtmlStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// JBXmlStatusLabel
			// 
			this.JBXmlStatusLabel.Name = "JBXmlStatusLabel";
			this.JBXmlStatusLabel.Size = new System.Drawing.Size(81, 17);
			this.JBXmlStatusLabel.Text = "[JB XML] 0 ms";
			// 
			// PluginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 298);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "PluginForm";
			this.ShowInTaskbar = false;
			this.Text = "Plugins Tester";
			this.Load += new System.EventHandler(this.PluginFormLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripStatusLabel JBXmlStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel XHtmlStatusLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox XHtmlTextBox;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TextBox SourceTextBox;
		private System.Windows.Forms.TextBox TargetTextBox;
		private System.Windows.Forms.Button CreateButton;
		private System.Windows.Forms.ComboBox PluginsComboBox;
		private System.Windows.Forms.ComboBox XslComboBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel CharacterStatusLabel;
	}
}
