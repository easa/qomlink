using System;
using System.Text;
using System.IO;
using System.Net;

namespace userCall.Models
{
    class Network
    {
        public static string connect(string website, string postdata)
        {
            console.log("Please wait..");
            try
            {
                WebRequest request = WebRequest.Create(url + website);
                string postData = postdata;
                request.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                //console.log(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                console.upline();
                return responseFromServer;
            }
            catch (Exception e)
            {
                console.upline();
                return e.Message;
            }
        }

        static string url = "http://182.16.20.1";
    }
}
