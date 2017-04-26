using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Common
{
    public class WebAPIHelper
    {
        public static string Get(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                if (request != null)
                {
                    string retval = null;
                    Init_Request(ref request);
                    using (var Response = request.GetResponse())
                    {
                        using (var reader = new System.IO.StreamReader(Response.GetResponseStream(), System.Text.Encoding.UTF8))
                        {
                            retval = reader.ReadToEnd();
                        }
                    }
                    return retval;
                }
            }
            catch
            {

            }
            return null;
        }
        public static string Post(string url, string data)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                if (request != null)
                {
                    string retval = null;
                    Init_Request(ref request);
                    request.Method = "POST";
                    request.ServicePoint.Expect100Continue = false;
                    request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
                    var bytes = System.Text.UTF8Encoding.UTF8.GetBytes(data);
                    request.ContentLength = bytes.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    using (var response = request.GetResponse())
                    {
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            url = reader.ReadToEnd();
                        }
                    }
                    return retval;
                }
            }
            catch
            {

            }
            return null;
        }

        private static void Init_Request(ref System.Net.HttpWebRequest request)
        {
            request.Accept = "text/json,*/*;q=0.5";
            request.Headers.Add("Accept-Charset", "utf-8;q=0.7,*;q=0.7");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, x-gzip, identity; q=0.9");
            request.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
            request.Timeout = 8000;
        }
    }
}
