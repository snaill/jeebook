using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Jeebook.FileServer
{
    /// <summary>
    /// 标识采用什么模式处理虚拟路径，即逗号以后的内容
    /// </summary>
    public enum VirtualPathMode
    {
        Unknown,
        Zip,
        Image
    }

    /// <summary>
    /// FileServer提供一种服务端虚拟文件的处理方式，包括直接存取压缩文件内容，图片的不同分辨率等
    /// FileServer使用JSON传输及缓存数据，如_dirs及_files用来保存目录下所有的文件及目录信息
    /// FileServer使用,作为存取压缩文件或图片不同版本的分隔符，如aaa.jb,index.htm或者aaa.jpg,240,480等等
    /// FileServer将下划线和逗号作为保留符号，不支持创建以"_"开头的文件或目录，或路径中包含","，创建时会自动过滤这些符号
    /// </summary>
    public class FileServerBase
    {
        const char PathDelimiter = ',';
        const string DirPrefix = "_";
        const string FileExtension = "";
        const string DirCacheName = "_dirs";
        const string FileCacheName = "_files";

    	string m_strBase = "";
        VirtualPathMode m_vMode = VirtualPathMode.Unknown;

        public FileServerBase(string strBase, VirtualPathMode vMode)
        {
            m_strBase = strBase;
            if ( !m_strBase.EndsWith("\\") )
            	m_strBase += '\\';
            m_vMode = vMode;
        }

        /// <summary>
        /// 返回指定路径下的所有目录
        /// </summary>
        /// <param name="strDir">指定目录</param>
        /// <returns>返回JSON文件的路径</returns>
        public string GetDirectories(string strDir)
        {
            string strPath = m_strBase + strDir;
            string strJson = strPath + DirCacheName;
            if (!System.IO.File.Exists(strJson))
            {
                string[] strDirs = System.IO.Directory.GetDirectories(strPath);

                System.IO.TextWriter tw = new System.IO.StreamWriter(strJson);
                JsonWriter jw = new JsonTextWriter(tw);
                jw.WriteStartArray();
                foreach ( string strD in strDirs )
                {
                	System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strD);
                    if (di.Name.StartsWith(DirPrefix) 
                        || (di.Attributes & System.IO.FileAttributes.Hidden) == System.IO.FileAttributes.Hidden)
                		continue;
                	
                    jw.WriteStartObject();
                    jw.WritePropertyName("name");
                    jw.WriteValue(di.Name);
                    jw.WritePropertyName("leaf");
                    jw.WriteValue( 0 == di.GetDirectories().Length );
                    jw.WriteEndObject();
                }
                jw.WriteEndArray();
                tw.Close();
            }

            return strJson;
        }
        
        /// <summary>
        /// 获取指定目录下的文件列表，可通过扩展名过滤
        /// </summary>
        /// <param name="strDir">指定目录</param>
        /// <returns>文件列表的缓存json文件路径</returns>
        public string GetFiles(string strDir)
        {
            string strPath = m_strBase + strDir;
            string strJson = strPath + FileCacheName;
            if (!System.IO.File.Exists(strJson))
            {
                string[] strFiles = System.IO.Directory.GetFiles(strPath);

                System.IO.TextWriter tw = new System.IO.StreamWriter(strJson);
                JsonWriter jw = new JsonTextWriter(tw);
                jw.WriteStartArray();
                foreach ( string strFile in strFiles )
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(strFile);
                	if ( ( !String.IsNullOrEmpty( FileExtension ) 
                	      && FileExtension.IndexOf(System.IO.Path.GetExtension( fi.Name )) < 0 )
                	    || fi.Name == DirCacheName || fi.Name == FileCacheName )
                		continue;
                 	
                    jw.WriteStartObject();
                    jw.WritePropertyName("name");
                    jw.WriteValue(fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length));
                    jw.WritePropertyName("size");
                    jw.WriteValue(fi.Length);
                    jw.WritePropertyName("time");
                    jw.WriteValue(string.Format("{0}-{1}-{2} {3}:{4}:{5}", fi.CreationTimeUtc.Year.ToString("D4"),
                        fi.CreationTimeUtc.Month.ToString("D2"), fi.CreationTimeUtc.Day.ToString("D2"),
                        fi.CreationTimeUtc.Hour.ToString("D2"), fi.CreationTimeUtc.Minute.ToString("D2"),
                        fi.CreationTimeUtc.Second.ToString("D2")));
                    jw.WritePropertyName("extension");
                    jw.WriteValue(fi.Extension);
                    jw.WriteEndObject();
                }
                jw.WriteEndArray();

                tw.Close();
            }

            return strJson;
        }

        /// <summary>
        /// 转换虚拟路径为绝对路径
        /// </summary>
        /// <param name="strDir">虚拟路径</param>
        /// <returns>绝对路径</returns>
        public string GetRealPath(string strDir)
        {
            if (strDir.IndexOf(PathDelimiter) < 0 || m_vMode == VirtualPathMode.Unknown)
                return System.IO.Path.Combine(m_strBase, strDir);

            string[] str = (m_strBase + strDir).Split(PathDelimiter);
            string strPath = str[0].Insert( str[0].LastIndexOf("\\") + 1, DirPrefix );
            switch (m_vMode)
            {
                case VirtualPathMode.Zip:
                    CheckCacheFolder(str[0], strPath, str[1]);
                    break;
            }

            return strPath + "/" + str[1];
         }

         public void CheckCacheFolder(string strSource, string strDir, string strFn)
         {
            if (!System.IO.Directory.Exists(strDir))
            {
                ICSharpCode.SharpZipLib.Zip.FastZip fz = new ICSharpCode.SharpZipLib.Zip.FastZip();
                fz.ExtractZip(strSource, strDir, "");
            }
        }

         public bool IsDirectory(string strPath)
         {
             return string.IsNullOrEmpty(strPath) || strPath[strPath.Length - 1] == '/';
         }

         public bool IsVirtualPath(string strPath)
         {
             return strPath.IndexOf(',') >= 0;
         }
    }
}
