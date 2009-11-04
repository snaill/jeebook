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
    public partial class BookView : System.Windows.Forms.RichTextBox
    {
        Book _book = null;
        Proxy _proxy = null;

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
