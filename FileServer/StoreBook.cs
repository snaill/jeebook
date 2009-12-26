using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Jeebook.FileServer;
using Jeebook.ROA;
using System.IO;

namespace Jeebook.Store.ROA
{
    class Book : BaseHandler
    {
        public override void do_Get(HttpContext context)
        {
            string strPath = context.Request.QueryString["path"];

            FileServerBase fs = new FileServerBase(context.Server.MapPath("../data/"), VirtualPathMode.Zip);
            if (fs.IsDirectory(strPath))
            {
                string dirs = fs.GetFiles(strPath);
                context.Response.WriteFile(dirs);
            }
            else if (fs.IsVirtualPath(strPath))
            {
                string realPath = fs.GetRealPath(strPath);
                context.Response.WriteFile(realPath);
            }
            else
            {
                Download(context.Request, context.Response, fs.GetRealPath(strPath));
            }
        }

        //public void do_Post(HttpContext context, string strPath)
        //{

        //}

        //public void do_Put(HttpContext context, string strPath)
        //{
        //}

        //public void do_Delete(HttpContext context, string strPath)
        //{
        //}

        public bool Download(HttpRequest _Request, HttpResponse _Response, string _fileName)
        {
            try
            {
                FileStream myFile = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(myFile);
                try
                {
                    _Response.AddHeader("Accept-Ranges", "bytes");
                    _Response.Buffer = false;
                    long startBytes = 0;
                    long endBytes = myFile.Length;

                    double pack = 10240; //10K bytes
                    int sleep = 200;   //每秒5次   即5*10K bytes每秒
                    if (_Request.Headers["Range"] != null)
                    {
                        _Response.StatusCode = HttpStatusCode.HTTP_206_PartialContent;
                        string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                        startBytes = Convert.ToInt64(range[1]);
                        endBytes = Convert.ToInt64(range[2]);
                    }
                    _Response.AddHeader("Content-Length", (endBytes - startBytes).ToString());
                    if (startBytes != 0)
                    {
                        _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, endBytes - 1, endBytes));
                    }
                    _Response.ContentType = "application/octet-stream";
                    _Response.Charset = "UTF-8";
                    _Response.AddHeader("Connection", "Keep-Alive");

                    HttpBrowserCapabilities bc = HttpContext.Current.Request.Browser;
                    if (bc.Browser == "IE")
                        _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(Path.GetFileName(_fileName), System.Text.Encoding.UTF8));
                    else
                        _Response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(_fileName));

                    br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                    int maxCount = (int)Math.Floor((endBytes - startBytes) / pack) + 1;

                    for (int i = 0; i < maxCount; i++)
                    {
                        if (_Response.IsClientConnected)
                        {
                            _Response.BinaryWrite(br.ReadBytes(int.Parse(pack.ToString())));
                            System.Threading.Thread.Sleep(sleep);
                        }
                        else
                        {
                            i = maxCount;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    br.Close();
                    myFile.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
