using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using QFramework;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class HttpClientMrg : MonoSingleton<HttpClientMrg>
{
    string HTTP_PATH = "http://127.0.0.1:80/";

    public async void DownLoadFile(string fileName, string localFilePath, UnityAction<HttpStatusCode> action)
    {
        HttpStatusCode result = HttpStatusCode.OK;
        await Task.Run(() =>
        {
            try
            {
                //HEAD请求用于判断文件是否存在
                HttpWebRequest req = HttpWebRequest.Create(new Uri(HTTP_PATH)) as HttpWebRequest;
                req.Method = WebRequestMethods.Http.Head;
                req.Timeout = 2000;
                req.Credentials = new NetworkCredential("Zheng", "dulin1215");
                req.PreAuthenticate = true;

                HttpWebResponse res = req.GetResponse() as HttpWebResponse;

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    res.Close();
                    req = HttpWebRequest.Create(HTTP_PATH + fileName) as HttpWebRequest;
                    req.Method = WebRequestMethods.Http.Get;
                    req.Timeout = 2000;
                    req.Credentials = new NetworkCredential("Zheng", "dulin1215");
                    req.PreAuthenticate = true;

                    res = req.GetResponse() as HttpWebResponse;
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        using (FileStream fileStream = File.Create(localFilePath))
                        {
                            Stream stream = res.GetResponseStream();
                            byte[] bytes = new byte[4096];
                            int contentLength = stream.Read(bytes, 0, bytes.Length);
                            while (contentLength != 0)
                            {
                                fileStream.Write(bytes, 0, contentLength);
                                contentLength = stream.Read(bytes, 0, bytes.Length);
                            }
                            fileStream.Close();
                            stream.Close();
                            res.Close();
                        }
                    }
                    result = res.StatusCode;
                }
                result = res.StatusCode;
            }
            catch (WebException w)
            {
                result = HttpStatusCode.InternalServerError;
            }
        });
        action?.Invoke(result);
    }
}