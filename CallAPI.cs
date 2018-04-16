using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace shree_agro
{
    class CallAPI
    {
        public static void POST(string url, string jsonContent)
        {
            //url = "blabla.com/api/blala" + url;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURL);
            //request.Method = "POST";

            //System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            //Byte[] byteArray = encoding.GetBytes(jsonContent);

            //request.ContentLength = byteArray.Length;
            //request.ContentType = @"application/json";

            //using (Stream dataStream = request.GetRequestStream())
            //{
            //    dataStream.Write(byteArray, 0, byteArray.Length);
            //}
            //long length = 0;
            //try
            //{
            //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //    {
            //        length = response.ContentLength;

            //    }
            //}
            //catch
            //{
            //    throw;
            //}
        }
    }
   
}
