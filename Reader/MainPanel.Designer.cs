namespace Jeebook.Reader
{
    partial class MainPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BookView = new Jeebook.Reader.BookView();
            this.ComicView = new Jeebook.Reader.ComicView();
            this.SuspendLayout();
            // 
            // BookView
            // 
            this.BookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookView.HiglightColor = Khendys.Controls.RtfColor.White;
            this.BookView.Location = new System.Drawing.Point(0, 0);
            this.BookView.Name = "BookView";
            this.BookView.Size = new System.Drawing.Size(100, 96);
            this.BookView.TabIndex = 0;
            this.BookView.Text = "";
            this.BookView.TextColor = Khendys.Controls.RtfColor.Black;
            this.BookView.Visible = false;
            this.Controls.Add(this.BookView);
            // 
            // ComicView
            // 
            this.ComicView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComicView.Location = new System.Drawing.Point(0, 0);
            this.ComicView.Name = "ComicView";
            this.ComicView.Size = new System.Drawing.Size(200, 100);
            this.ComicView.TabIndex = 0;
            this.ComicView.Visible = false;
            this.Controls.Add(this.ComicView);

            this.ResumeLayout(false);

        }

        #endregion

        private BookView BookView;
        private ComicView ComicView;
    }
}
