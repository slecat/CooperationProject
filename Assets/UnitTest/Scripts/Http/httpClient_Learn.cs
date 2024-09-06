using System;
using System.IO;
using System.Net;
using UnityEngine;

public class httpClient_Learn : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        HttpWebRequest req = HttpWebRequest.Create(new Uri("http://127.0.0.1/测试文件.txt")) as HttpWebRequest;
        //请求类型
        req.Method = WebRequestMethods.Http.Get;
        //超时时间
        req.Timeout = 2000;
        //身份认证
        req.Credentials = new NetworkCredential("Zheng", "dulin1215");
        req.PreAuthenticate = true;
        //发送请求并获取响应
        HttpWebResponse res = req.GetResponse() as HttpWebResponse;
        if (res.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log("请求成功");
            using (FileStream fileStream = File.Create(Application.persistentDataPath + "/HttpDownload.txt"))
            {
                Stream downLoadStream = res.GetResponseStream();
                byte[] bytes = new byte[2048];
                //读取数据
                int contentLength = downLoadStream.Read(bytes, 0, bytes.Length);
                while (contentLength != 0)
                {
                    fileStream.Write(bytes, 0, contentLength);
                    contentLength = downLoadStream.Read(bytes, 0, bytes.Length);
                }
                fileStream.Close();
                downLoadStream.Close();
            }
            Debug.Log("下载成功");
        }
        else
        {
            Debug.Log("请求失败");
        }

        //下载资源

    }
}