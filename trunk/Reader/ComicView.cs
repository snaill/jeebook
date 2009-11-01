﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeebook.Base;

namespace Jeebook.Reader
{
    public partial class ComicView : System.Windows.Forms.Panel
    {
        const int ImageMinMove = 20;
        MediaObject _media = null;
        Proxy _proxy = null;
        int _index = 0;

        public ComicView(MediaObject media, Proxy proxy)
        {
            InitializeComponent();

            _media = media;
            _proxy = proxy;

            Load(_index);
        }

        public void Load(int index)
        {
            if (index < 0 || index >= _media.Objects.Count)
                return;

            System.IO.Stream stream = _proxy.GetFileStream(_media.Objects[index].FileRef);
            ImageBox.Image = System.Drawing.Image.FromStream(stream);
            stream.Close();

            ResizeImageBox();   
        }

        public void ResizeImageBox()
        {
            //
            if (this.Width < ImageBox.Image.Width)
            {
                ImageBox.Height = ImageBox.Image.Height * this.Width / ImageBox.Image.Width;
                ImageBox.Width = this.Width;
            }

            ImageBox.Left = (this.Width - ImageBox.Width) / 2;
            ImageBox.Top = 0;
        }

        private void ComicView_Resize(object sender, EventArgs e)
        {
            ResizeImageBox();
        }

        private void ComicView_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Windows.Forms.Keys keyData = e.Delta > 0 ? System.Windows.Forms.Keys.Down : System.Windows.Forms.Keys.Up;
            System.Windows.Forms.KeyEventArgs args = new System.Windows.Forms.KeyEventArgs( keyData );
            OnKeyDown( args );
        }
        
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
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
                        if (_index == _media.Objects.Count - 1)
                            return;

                        Load(++_index);
                        break;
                    }
                case System.Windows.Forms.Keys.Up:
                    {
                        if (ImageBox.Top >= 0)
                            return;

                        ImageBox.Top += (ImageMinMove < -ImageBox.Top) ? ImageMinMove : -ImageBox.Top;
                        break;
                    }
                case System.Windows.Forms.Keys.Down:
                    {
                        if (ImageBox.Bottom <= this.Height)
                            return;

                        ImageBox.Top -= (ImageMinMove < ImageBox.Bottom - this.Height) ? ImageMinMove : ImageBox.Bottom - this.Height;
                        break;
                    }
            }
            base.OnKeyDown(e);
        }
    }
}
