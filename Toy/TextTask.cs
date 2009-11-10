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

        const int MaxSize = Int16.MaxValue;

        public TextTask(string url, string strJBPath)
		{
			Uri = url;
			JBPath = strJBPath;	
		}

        public override void Run()
        {
            string title = this.Uri.Substring( this.Uri.LastIndexOf('\\') + 1 );
            title = title.Substring(0, title.LastIndexOf('.'));
            this.Name = title;

            JBPath += title + ".jb";
            ZipFile zf = ZipFile.Create(JBPath);

            Book book = new Book();
            book.Info = new Info(title, new Author("Unknown"), title + ".txt");
            book.Links = new List<ChapterLink>();

            //
            TaskStateChangedEventArgs args = new TaskStateChangedEventArgs(this);
            State = TaskState.ToJeebook;

            System.IO.StreamReader sr = new System.IO.StreamReader(this.Uri, System.Text.Encoding.Default);
            int index = 0;
            string strFilename = "";
            while (!sr.EndOfStream)
            {
                args.CurrentUri = index.ToString("D4") + ".xml";
                args.FinishedCount = index;
                args.TotalCount = index;
                if (TaskStateChanged != null)
                    TaskStateChanged(args);

                int szReader = 0;
                Chapter chap = new Chapter();
                chap.Title = "";
                chap.Paras = new List<Para>();
                while ( !sr.EndOfStream && szReader < MaxSize  )
                {
                    string strTemp = sr.ReadLine();
                    strTemp = strTemp.Trim(" \r\n\t".ToCharArray());
                    if (strTemp.Length == 0)
                        continue;

                    szReader += strTemp.Length;
                    chap.Paras.Add(new Para(strTemp));
                }

                if (0 == chap.Paras.Count)
                    continue;

                //
                strFilename = System.IO.Path.GetTempFileName();
                chap.Save(strFilename);
                zf.BeginUpdate();
                zf.Add(strFilename, index.ToString("D4") + ".xml");
                zf.CommitUpdate();
                System.IO.File.Delete(strFilename);

                book.Links.Add(new ChapterLink(index.ToString("D4") + ".xml", index.ToString("D4")));
                index++;
            }
            sr.Close();

            //
            State = TaskState.Packaging;
            if (TaskStateChanged != null)
                TaskStateChanged(args);

            //
            strFilename = System.IO.Path.GetTempFileName();
            book.Save(strFilename);
            zf.BeginUpdate();
            zf.Add(strFilename, "index.xml");
            zf.CommitUpdate();
            zf.Close();

            //
            System.IO.File.Delete(strFilename);

            //
            State = TaskState.Finished;
            if (TaskStateChanged != null)
                TaskStateChanged(args);

        }
    }
}

