﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeebook.Base;
using ICSharpCode.SharpZipLib.Zip;

namespace Jeebook.Toy
{
    class ComicTask : Task, ITaskNotify
	{
		public event TaskStateChangedHandler TaskStateChanged;

        public ComicTask( string url, string strJBPath)
		{
			Uri = url;
			JBPath = strJBPath;	
		}

        public override void Run()
        {
            string title = this.Uri;
            if (title.EndsWith("\\"))
                title.Substring(0, title.Length - 1);
            title = title.Substring(title.LastIndexOf("\\") + 1);
            this.Name = title;

            TaskStateChangedEventArgs args = new TaskStateChangedEventArgs(this);
            args.CurrentUri = this.Uri;
            State = TaskState.Analysing;
            if (TaskStateChanged != null)
                TaskStateChanged(args);

            JBPath += title + ".jb";
            ZipFile zf = ZipFile.Create(JBPath); 
            zf.BeginUpdate();
            zf.AddDirectory("images");
            
            MediaObject mo = new MediaObject();
            mo.Objects = new List<ImageObject>();

            string[] files = System.IO.Directory.GetFiles(this.Uri, "*.jpg");
            foreach ( string file in files )
            {
                string fn = "images\\" + file.Substring(file.LastIndexOf('\\') + 1);
                zf.Add(file, fn);
                mo.Objects.Add(new ImageObject(fn, ""));
            }

            //
            State = TaskState.ToJeebook;
            if (TaskStateChanged != null)
                TaskStateChanged(args);

            Book book = new Book();
            book.Info = new Info(title, new Author("Unknown"), "Unknown");
            book.MediaObject = mo;

            string fnBook = System.IO.Path.GetTempFileName();
            book.Save(fnBook);
            zf.Add(fnBook, "index.xml");

            State = TaskState.Packaging;
            if (TaskStateChanged != null)
                TaskStateChanged(args);
            zf.CommitUpdate();
            zf.Close();

            State = TaskState.Finished;
            if (TaskStateChanged != null)
                TaskStateChanged(args);

        }
    }
}
