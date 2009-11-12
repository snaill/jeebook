﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Jeebook.FileServer
{
    public delegate void CheckCacheFolder(string strSource, string strDir, string strFn);

    public class FileServerBase
    {
        const string DirPrefix = "__";
        const string FileExtension = "";
        const string DirCacheName = "dirs.json";
        const string FileCacheName = "files.json";

    	string m_strBase = "";

        public event CheckCacheFolder OnCheckCacheFolder = null;

        public FileServerBase(string strBase)
        {
            m_strBase = strBase;
            if ( !m_strBase.EndsWith("\\") )
            	m_strBase += '\\';
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
                if (strDirs.Length == 0)
                    return null;

                System.IO.TextWriter tw = new System.IO.StreamWriter(strJson);
                JsonWriter jw = new JsonTextWriter(tw);
                jw.WriteStartObject();
                jw.WritePropertyName("success");
                jw.WriteValue(true);
                jw.WritePropertyName("data");
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
                    jw.WriteValue(true);
                    jw.WriteEndObject();
                }
                jw.WriteEndArray();
                jw.WriteEndObject();

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
                if (strFiles.Length == 0)
                    return null;

                System.IO.TextWriter tw = new System.IO.StreamWriter(strJson);
                JsonWriter jw = new JsonTextWriter(tw);
                jw.WriteStartObject();
                jw.WritePropertyName("success");
                jw.WriteValue(true);
                jw.WritePropertyName("data");
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
                jw.WriteEndObject();

                tw.Close();
            }

            return strJson;
        }

        public string Get(string strDir)
        {
            if (strDir.IndexOf('#') < 0)
                return strDir;

            string[] str = strDir.Split('#');
            string strPath = str[0].Insert( str[0].LastIndexOf("\\"), DirPrefix );
            if (OnCheckCacheFolder != null)
                OnCheckCacheFolder(str[0], strPath, str[1]);

            return strPath + "\\" + str[1];
         }
    }
}
