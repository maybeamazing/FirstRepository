using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAcquisition
{
    class HttpCom
    {
        public static string Post(string sContent)
        {
            try
            {
                string strPost = sContent;
                byte[] buffer = Encoding.UTF8.GetBytes(strPost);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://127.0.0.1:1185/Write/" + buffer.Length);
                request.Method = "POST";
                request.ContentType = "text/plain";

                request.ContentLength = buffer.Length;
                Stream requestStram = request.GetRequestStream();
                requestStram.Write(buffer, 0, buffer.Length);
                requestStram.Close();

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                string str1 = GetResponseString(response);
                return str1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string GetResponseString(HttpWebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();

            }
        }
    }
}
