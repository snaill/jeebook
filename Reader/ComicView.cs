using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JeebookReader
{
    class ComicView : System.Windows.Forms.PictureBox
    {

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
