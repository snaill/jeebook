using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Jeebook.Base
{
    public class HttpProxy : Proxy
    {
        string _uri = "";
        public HttpProxy(string uri)
        {
            _uri = ParseUrl(uri);
        }

        public System.IO.Stream GetFileStream(string fn)
        {
            System.Net.WebRequest request = System.Net.HttpWebRequest.Create(_uri + "|" + fn);
            System.Net.WebResponse response = request.GetResponse();
            return response.GetResponseStream();
        }
        
        string ParseUrl(string url)
        {
            Uri uri = new Uri(url);

            NameValueCollection nvc = new NameValueCollection();
            string ps = uri.Query + uri.Fragment;

            // 开始分析参数对    
            Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
            MatchCollection mc = re.Matches(ps);

            foreach (Match m in mc)
            {
                nvc.Add(m.Result("$2"), m.Result("$3"));
            }

            string strUrl = "http://" + uri.Authority + uri.LocalPath + "?";
            foreach( string key in nvc.Keys )
            {
                if (key == "path")
                    continue;

                strUrl += key + "=" + nvc[key] + '&';
            }
            strUrl += "path=" + nvc["path"];
            return strUrl;
        }
    }
}
