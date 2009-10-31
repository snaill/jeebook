using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeebook.Base;

namespace Jeebook.Reader
{
    class ComicView : System.Windows.Forms.PictureBox
    {

        public ComicView(Book book, Proxy proxy)
        {
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ComicView
            // 
            this.WaitOnLoad = true;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

    }
}
