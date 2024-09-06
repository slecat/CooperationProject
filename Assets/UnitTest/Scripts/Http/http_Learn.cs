using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class http_Learn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //创建请求
        HttpWebRequest req = HttpWebRequest.Create(new Uri("http://127.0.0.1:80")) as HttpWebRequest;
        //用于上传的流
        Stream s = req.GetRequestStream();
        //返回服务器响应
        HttpWebResponse res = req.GetResponse() as HttpWebResponse;
        //身份认证
        req.Credentials = new NetworkCredential("", "");
        req.PreAuthenticate = true;
        //发送的消息长度
        req.ContentLength = 100;
        //数据 类型
        req.ContentType = "";
        //请求方式
        req.Method = WebRequestMethods.Http.Get;

        //关闭流
        // res.Close()

        //返回的长度
        // res.ContentLength
        //返回的数据类型
        // res.ContentType


    }

    // Update is called once per frame
    void Update()
    {

    }
}
