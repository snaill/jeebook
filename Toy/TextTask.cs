using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeebook.Base;
using ICSharpCode.SharpZipLib.Zip;

namespace Jeebook.Toy
{
    class TextTask : Task, ITaskNotify
	{
		public event TaskStateChangedHandler TaskStateChanged;

        const int MaxSize = UInt16.MaxValue;

        public override void Run()
        {
            TaskStateChangedEventArgs args = new TaskStateChangedEventArgs(this);
            args.Url = this.Uri;
            State = TaskState.Analysing;
            if (TaskStateChanged != null)
                TaskStateChanged(args);

            string title = args.Url.Substring( args.Url.LastIndexOf('\\') + 1 );
            title = title.Substring(args.Url.LastIndexOf('.'));

            ZipFile zf = ZipFile.Create(JBPath + title + ".jb");
            zf.BeginUpdate();

            Book book = new Book();
            book.Info = new Info(title, new Author("Unknown"), "Unknown");
            book.Links = new List<ChapterLink>();

            System.IO.StreamReader sr = new System.IO.StreamReader(args.Url);

            //
            string strTemp = "";
            while (!sr.EndOfStream)
            {
                strTemp = System.IO.Path.GetTempFileName();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(strTemp, false, System.Text.Encoding.Unicode);
                int size = sr.BaseStream.Length - sr.BaseStream.Position < MaxSize * 2 ? MaxSize / 2 : MaxSize;

                Chapter chap = new Chapter();
                chap.Elements = new List<Element>();
                chap.Title = "001";
                chap.Uri = "001.xml";
                string str = sr.ReadLine();
                chap.Elements.Add(new Para(str));

                zf.Add(strTemp, chap.Uri);
                book.Links.Add(new ChapterLink(chap.Uri, chap.Title));
            }
            sr.Close();

            //
            State = TaskState.ToJeebook;
            if (TaskStateChanged != null)
                TaskStateChanged(args);

            strTemp = System.IO.Path.GetTempFileName();
            book.Save(strTemp);
            zf.Add(strTemp, "index.xml");

            //
            State = TaskState.Packaging;
            if (TaskStateChanged != null)
                TaskStateChanged(args);
            zf.CommitUpdate();
            zf.Close();

            //
            State = TaskState.Finished;
            if (TaskStateChanged != null)
                TaskStateChanged(args);

        }
    }
}

