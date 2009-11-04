using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using Jeebook.Base;
using Microsoft.Win32;

namespace Jeebook.Reader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadJeebook(string uri)
        {
            Proxy proxy = null;
            if (uri.StartsWith("jeebook://", StringComparison.OrdinalIgnoreCase))
            {
                proxy = new HttpProxy(uri);
            }
            else if (System.IO.Directory.Exists(uri))
            {
                proxy = new FileProxy(uri);
            }
            else if (System.IO.File.Exists(uri) && uri.EndsWith(".jb", StringComparison.OrdinalIgnoreCase))
            {
                proxy = new ZipProxy(uri);
            }
            else
                return;

            System.IO.Stream stream = null;
            try
            {
                //
                stream = proxy.GetFileStream("index.xml");
                Book book = Book.Create(stream);
                stream.Close();

                if (book.MediaObject != null)
                {
                    ComicView cv = new ComicView(book.MediaObject, proxy);
                    this.Controls.Add(cv);
                    cv.Focus();
                }
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void RegFormatAndProtocol()
        {
            if ( null != Registry.ClassesRoot.OpenSubKey(".jb") 
                && null != Registry.ClassesRoot.OpenSubKey("jeebook") )
                return;

            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new WindowsPrincipal(wi);

            if (!wp.IsInRole(WindowsBuiltInRole.Administrator))
            {
                System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                start.WorkingDirectory = System.Windows.Forms.Application.StartupPath;
                start.Verb = "runas";
                start.FileName = System.Windows.Forms.Application.ExecutablePath;
                System.Diagnostics.Process.Start(start);
                Application.Exit();
                return;
            }

            RegistryKey key = Registry.ClassesRoot.OpenSubKey(".jb");
            if (key == null)
            {
                key = Registry.ClassesRoot.CreateSubKey(".jb");
                key.SetValue("", "Jeebook.Reader.jb");
                key.SetValue("Content Type", "application/jb");

                key = Registry.ClassesRoot.CreateSubKey("Jeebook.Reader.jb");
                key.SetValue("", "Jeebook Document");

                RegistryKey keySub = key.CreateSubKey("DefaultIcon");
                keySub.SetValue("", System.Windows.Forms.Application.StartupPath + "Jeebook.ico");
                keySub = key.CreateSubKey("shell\\open\\command");
                keySub.SetValue("", "\"" + System.Windows.Forms.Application.ExecutablePath + "\" \"%1\"");
            }

            key = Registry.ClassesRoot.OpenSubKey("jeebook");
            if (key == null)
            {
                key = Registry.ClassesRoot.CreateSubKey("jeebook");
                key.SetValue("", "URL:Jeebook Protocol");
                key.SetValue("URL Procotol", "");

                key = key.CreateSubKey("shell\\open\\command");
                key.SetValue("", "\"" + System.Windows.Forms.Application.ExecutablePath + "\" \"%1\"");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegFormatAndProtocol();

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
                return;

            LoadJeebook(args[1]);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None; 
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string strFile = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                LoadJeebook(strFile);
            }
            catch { 
            
            }
        }
    }
}
