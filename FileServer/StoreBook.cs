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

        public override void do_Post(HttpContext context)
        {
            // 
            string strPath = context.Server.MapPath("../data/upload/");
            for (int i = 0; i < context.Request.Files.Count; i ++ )
            {
                string strFilename = strPath + FileName2Path(context.Request.Files[i].FileName);
                string strDir = System.IO.Path.GetDirectoryName(strFilename);
                System.IO.Directory.CreateDirectory(strDir);
                context.Request.Files[0].SaveAs(strFilename);
                FileServerBase.ResetDirectory(strDir);
                FileServerBase.ResetDirectory(System.IO.Path.GetDirectoryName(strDir));
            }
        }

        //public override void do_Put(HttpContext context, string strPath)
        //{
        //}

        //public override void do_Delete(HttpContext context, string strPath)
        //{
        //}

        public string FileName2Path( string strFilename )
        {
            if ( IsChineseLetter( strFilename, 0 ) )
                return GetCharSpellCode( strFilename[0] ) + "/" + strFilename;

            return strFilename[0].ToString().ToUpper()  + "/" + strFilename;
        }

        protected bool  IsChineseLetter(string input,int index)
        {
            int code = 0;
            int chfrom = Convert.ToInt32("4e00", 16);    //范围（0x4e00～0x9fff）转换成int（chfrom～chend）
            int chend = Convert.ToInt32("9fff", 16);
            if (input != "")
            {
                code = Char.ConvertToUtf32(input, index);    //获得字符串input中指定索引index处字符unicode编码

                if (code >= chfrom && code <= chend)
                {
                    return true;     //当code在中文范围内返回true
                }
                else
                {
                    return false ;    //当code不在中文范围内返回false
                }
            }
            return false;
        }

        private static char GetCharSpellCode(char c)
        {
            byte[] data = Encoding.GetEncoding("gb2312").GetBytes(c.ToString());
            ushort code = (ushort)((data[0] << 8) + data[1]);
            ushort[] areaCode = {45217,45253,45761,46318,46826,47010,47297,47614,48119,48119,49062,49324,
                    49896,50371,50614,50622,50906,51387,51446,52218,52698,52698,52698,52980,53689,54481, 55290};

            for (int i = 0; i < 26; i++)
            {
                if (code>=areaCode[i] && code < (ushort)(areaCode[i + 1] - 1))
                    return (char)('A' + i);
            }

            return c;
        }

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
