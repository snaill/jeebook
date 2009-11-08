using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Jeebook.Base;

namespace Jeebook.Reader
{
    public delegate void KeyEventHandler(System.Windows.Forms.KeyEventArgs args);

    public partial class MainPanel : System.Windows.Forms.Panel
    {
        string _uri = "";
        Proxy _proxy = null;
        Book _book = null;
        int _index = 0;

        public MainPanel()
        {
            InitializeComponent();

            BookView.OnKeyEvent += OnKeyEvent;
            ComicView.OnKeyEvent += OnKeyEvent;
        }

        public string Uri
        {
            get { return _uri; }
            set
            {
                Load(value);
                _uri = value;
            }
        }

        void Reset()
        {
            BookView.Visible = false;
            ComicView.Visible = false;
        }

        private void Load(string uri)
        {
            Reset();

            _proxy = null;
            if (uri.StartsWith("jeebook://", StringComparison.OrdinalIgnoreCase))
            {
                _proxy = new HttpProxy(uri);
            }
            else if (System.IO.Directory.Exists(uri))
            {
                _proxy = new FileProxy(uri);
            }
            else if (System.IO.File.Exists(uri) && uri.EndsWith(".jb", StringComparison.OrdinalIgnoreCase))
            {
                _proxy = new ZipProxy(uri);
            }
            else
                return;

            System.IO.Stream stream = null;
            try
            {
                //
                stream = _proxy.GetFileStream("index.xml");
                _book = Book.Create(stream);
                stream.Close();

                if (_book.MediaObject != null)
                {
                    ComicView.Load(_book.MediaObject, _proxy);
                    ComicView.Visible = true;
                    ComicView.Focus();
                }
                else
                {
                    Load(0);
                }
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Load(int index)
        {
            if (index < 0 || index >= _book.Links.Count)
                return;

            Reset();

            System.IO.Stream stream = _proxy.GetFileStream(_book.Links[index].Href);
            Chapter chap = Chapter.Create(stream);
            stream.Close();

            if (chap.MediaObject != null)
            {
                ComicView.Load(chap.MediaObject, _proxy);
                ComicView.Visible = true;
                ComicView.Focus();
            }
            else
            {
                BookView.Load(chap, _proxy);
                BookView.Visible = true;
                BookView.Focus();
            }
            _index = index;
        }

        void OnKeyEvent(System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Left:
                    {
                        if (_index == 0)
                            return;

                        Load(--_index);
                        break;
                    }
                case System.Windows.Forms.Keys.Right:
                    {
                        if (_index == _book.Links.Count - 1)
                            return;

                        Load(++_index);
                        break;
                    }
            }
        }
    }
}
