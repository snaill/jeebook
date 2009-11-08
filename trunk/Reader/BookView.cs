using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Jeebook.Base;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Jeebook.Reader
{
    public partial class BookView : Khendys.Controls.ExRichTextBox
    {
        public event KeyEventHandler OnKeyEvent;

        public BookView() 
        {
            InitializeComponent();

            Font = new System.Drawing.Font("System", 13);
        }

        public void Load( Chapter chap, Proxy proxy )
        {
            HideCaret(this.Handle);

            InitializeComponent();

            foreach (Para p in chap.Paras)
            {
                foreach (Element elem in p.Elements)
                {
                    if (elem.GetType() == typeof(Text))
                        AppendTextAsRtf( (elem as Text).Value, this.Font ); 
                    else if (elem.GetType() == typeof(Link))
                    {
                        Link link = (Link)elem;
                        StringBuilder sb = new StringBuilder();
                        sb.Append(RTF_HEADER);
                        //sb.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang" + System.Globalization.CultureInfo.InstalledUICulture.LCID);
                        sb.Append(@"{\fonttbl{\f0\fnil\fcharset" + Font.GdiCharSet.ToString() + " " + EncodeAnsi(this.Font.Name) + ";}}");
                        sb.Append(@"\f0\fs" + (int)Math.Round((2 * Font.SizeInPoints)));
                        sb.Append("{\\field{\\*\\fldinst{HYPERLINK \"");
                        sb.Append(link.Href);
                        sb.Append("\" }}{\\fldrslt{\\cf2\\ul ");
                        sb.Append(EncodeAnsi(link.Value));
                        sb.Append("}}}");

                        AppendRtf(sb.ToString());
                    }
                    else if (elem.GetType() == typeof(MediaObject))
                    {
                        MediaObject mo = (MediaObject)elem;
                        foreach (ImageObject io in mo.Objects)
                        {
                            System.IO.Stream stream = proxy.GetFileStream(io.FileRef);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                            stream.Close();
                            InsertImage(image);
                        }
                    }
                }
                AppendTextAsRtf("\r\n\r\n");
            }

            this.Select(0, 0);
            this.ScrollToCaret();
        }

        public string EncodeUnicode(string str)
        {
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c <= 0x7f)
                    sb.Append(c);
                else
                    sb.Append("\\u" + Convert.ToUInt32(c) + "?");
            }
            return sb.ToString();
        }

        public string EncodeAnsi(string str)
        {
            var sb = new StringBuilder();
            byte[] bs = System.Text.Encoding.Default.GetBytes(str);
            foreach (byte b in bs)
            {
                if (b <= 0x7f)
                    sb.Append((char)b);
                else
                    sb.Append("\\'" + b.ToString("X"));
            }
            return sb.ToString();
        }

        [DllImport("user32.dll")]
        public static extern System.Int32 HideCaret(System.IntPtr hwnd);

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (null != OnKeyEvent)
                OnKeyEvent(e);
        }

        private void BookView_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
