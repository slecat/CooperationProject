using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using QFramework;
using UnityEngine;

namespace SimpleHttpClient
{
    [Serializable]
    public class RequestResult
    {
        public bool isSuccess;
    }
    public class HttpUitls
    {
        // public static string Get(string Url)
        // {
        //     HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        //     request.Proxy = null;
        //     request.KeepAlive = false;
        //     request.Method = "GET";
        //     request.ContentType = "application/json; charset=UTF-8";
        //     request.AutomaticDecompression = DecompressionMethods.GZip;

        //     HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //     Stream myResponseStream = response.GetResponseStream();
        //     StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
        //     string retString = myStreamReader.ReadToEnd();

        //     myStreamReader.Close();
        //     myResponseStream.Close();

        //     if (response != null)
        //     {
        //         response.Close();
        //     }
        //     if (request != null)
        //     {
        //         request.Abort();
        //     }

        //     return retString;
        // }

        // public static string Post(string Url, string Data)
        // {
        //     HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        //     request.Method = "POST";
        //     byte[] bytes = Encoding.UTF8.GetBytes(Data);
        //     request.ContentType = "application/x-www-form-urlencoded";
        //     request.ContentLength = bytes.Length;
        //     Stream myResponseStream = request.GetRequestStream();
        //     myResponseStream.Write(bytes, 0, bytes.Length);

        //     HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //     StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        //     string retString = myStreamReader.ReadToEnd();

        //     myStreamReader.Close();
        //     myResponseStream.Close();

        //     if (response != null)
        //     {
        //         response.Close();
        //     }
        //     if (request != null)
        //     {
        //         request.Abort();
        //     }
        //     return retString;
        // }



        public static async Task<string> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode(); // 确保 HTTP 响应状态码是 200-299
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }

        public static async Task<RequestResult> PostRequest(string url, Dictionary<string, string> formData)
        {
            using (HttpClient client = new HttpClient())
            {
                // 创建表单内容
                HttpContent content = new FormUrlEncodedContent(formData);

                // 发送 POST 请求
                HttpResponseMessage response = await client.PostAsync(url, content);

                // 确保请求成功
                response.EnsureSuccessStatusCode();

                // 读取响应内容
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonUtility.FromJson<RequestResult>(responseBody);
                // 打印响应内容
                // Debug.Log(responseBody);
            }
        }
    }
}