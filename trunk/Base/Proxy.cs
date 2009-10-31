using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeebook.Base
{
    public interface Proxy
    {
        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="fn">文件路径</param>
        /// <returns>用于读取文件的流</returns>
        System.IO.Stream GetFileStream(string fn);
    }
}
