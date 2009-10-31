/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Windows.Forms;

namespace JeebookToy
{
	/// <summary>
	/// Description of PluginForm.
	/// </summary>
	public partial class TesterForm : Form
	{
		public TesterForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void PluginFormLoad(object sender, EventArgs e)
		{
			string strPath = System.Windows.Forms.Application.StartupPath + "\\plugins\\";
			string[] dirs = System.IO.Directory.GetDirectories(strPath);
			for ( int i = 0; i < dirs.Length; i ++ )
			{
				PluginsComboBox.Items.Add( dirs[i].Substring( strPath.Length ) );
			}
			if ( PluginsComboBox.Items.Count > 0 )
				PluginsComboBox.SelectedIndex = 0;
		}
		
		void PluginsComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			if ( PluginsComboBox.Text == "" )
				return;
			
			string strPath = System.Windows.Forms.Application.StartupPath + "\\plugins\\" + PluginsComboBox.Text + "\\";
			string[] files = System.IO.Directory.GetFiles(strPath, "*.xslt");
			for ( int i = 0; i < files.Length; i ++ )
			{
				XslComboBox.Items.Add( files[i].Substring( strPath.Length ) );
			}
			if ( XslComboBox.Items.Count > 0 )
				XslComboBox.SelectedIndex = 0;
		}
		
		void CreateButtonClick(object sender, EventArgs e)
		{
			//
			XHtmlTextBox.Text = "";
			TargetTextBox.Text = "";
            XHtmlStatusLabel.Text = "[XHtml] 0 ms";
            JBXmlStatusLabel.Text = "[JB XML] 0 ms";
            CharacterStatusLabel.Text = "0 character";

            //
            DateTime dtStart = System.DateTime.Now;

            //
            XHtmlTextBox.Text = Task.Html2XHtml( SourceTextBox.Text );
            XHtmlStatusLabel.Text = "[XHtml] " + ((int)(System.DateTime.Now - dtStart).TotalMilliseconds).ToString() + " ms";
            dtStart = System.DateTime.Now;
            
			//
			TargetTextBox.Text = Task.Transform( XHtmlTextBox.Text, System.Windows.Forms.Application.StartupPath + "\\plugins\\" + PluginsComboBox.Text + "\\" + XslComboBox.Text );
    		JBXmlStatusLabel.Text = "[JB XML] " + ((int)(System.DateTime.Now - dtStart).TotalMilliseconds).ToString() + " ms";
       
			//
            CharacterStatusLabel.Text = TargetTextBox.Text.Length.ToString() + " characters";
		}
		
		void SourceTextBoxDoubleClick(object sender, EventArgs e)
		{
			SourceTextBox.SelectAll();
		}
		
		void TargetTextBoxDoubleClick(object sender, EventArgs e)
		{
			TargetTextBox.SelectAll();
		}
		
        private void XHtmlTextBoxDoubleClick(object sender, EventArgs e)
        {
            XHtmlTextBox.SelectAll();
        }
	}
}
