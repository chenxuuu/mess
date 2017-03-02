using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length==0)
            {
                Console.Write("请填写网址参数！");
            }
            else
            {
                int count = 0;
                while (true)
                {
                    Console.Write("get:"+args[0]);
                    try
                    {
                        HttpGet(args[0], "");
                    }
                    catch
                    {
                        Console.Write("失败！");
                    }
                    Console.WriteLine("已执行" + count + "次");
                    count++;
                }
            }
        }


        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}
