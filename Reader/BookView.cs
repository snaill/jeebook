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
        Book _book = null;
        Proxy _proxy = null;
        int _index = 0;

        private const int WM_SETFOCUS = 0x7;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101; 

        public BookView( Book book, Proxy proxy )
        {
            HideCaret(this.Handle);

            InitializeComponent();
            _book = book;
            _proxy = proxy;

            Load(_index);
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

        public void Load(int index)
        {
            if (index < 0 || index >= _book.Links.Count)
                return;

            System.IO.Stream stream = _proxy.GetFileStream(_book.Links[index].Href);
            Chapter chap = Chapter.Create(stream);
            stream.Close();

            foreach (Para p in chap.Paras)
            {
                foreach (Element elem in p.Elements)
                {
                    if (elem.GetType() == typeof(Text))
                        AppendText(((Text)elem).Value);
                    else if (elem.GetType() == typeof(Link))
                    {
                        Link link = (Link)elem;
                        StringBuilder sb = new StringBuilder();
                        sb.Append(RTF_HEADER);
                        //sb.Append(@"{\rtf1\ansi\ansicpg1252\deff0\deflang" + System.Globalization.CultureInfo.InstalledUICulture.LCID);
                        sb.Append(@"{\fonttbl{\f0\fnil\fcharset" + Font.GdiCharSet.ToString() + " " + EncodeAnsi(this.Font.Name) + ";}}");
                        sb.Append("{\\field{\\*\\fldinst{HYPERLINK \"");
                        sb.Append(link.Href);
                        sb.Append("\" }}{\\fldrslt{\\cf2\\ul ");
                        sb.Append(EncodeAnsi("李明"));
                        sb.Append("}}}");

                       
                        string str = sb.ToString();
                        AppendRtf(sb.ToString());
                    }
                    else if (elem.GetType() == typeof(MediaObject))
                    {
                        MediaObject mo = (MediaObject)elem;
                        foreach (ImageObject io in mo.Objects)
                        {
                            stream = _proxy.GetFileStream(io.FileRef);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                            stream.Close();
                            InsertImage(image);
                        }
                    }
                }
                AppendTextAsRtf("\r\n\r\n");
            }
        }

        [DllImport("user32.dll")]
        public static extern System.Int32 HideCaret(System.IntPtr hwnd);

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_SETFOCUS || m.Msg == WM_KEYDOWN || m.Msg == WM_KEYUP || m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONUP || m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_RBUTTONDOWN || m.Msg == WM_RBUTTONUP || m.Msg == WM_RBUTTONDBLCLK)
            {
                return;
            }
            base.WndProc(ref m);
        } 
    }
}
