using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpClient;
using UnityEngine;

public class HttpTest : MonoBehaviour
{
    private async void Start()
    {
        // HttpClientMrg.Instance.DownLoadFile("测试文件.txt", Application.persistentDataPath + "/测试文件.txt", (code) =>
        // {
        //     Debug.Log(code);
        //     if (code == HttpStatusCode.OK)
        //     {
        //         Debug.Log("下载成功");
        //     }
        // });
        string url = "http://112.124.22.247:8888";
        string account = "1528449507";
        string password = "dulin1215";
        string data = $"account={account}&password={password}";
        var formData = new Dictionary<string, string>
        {
            { "account", account },
            { "password", password }
        };
        string result = await PostRequest(url + "/login", formData);
        // Debug.Log(HttpUitls.Get(url));
        // HttpUitls.Post(url + "/login", data);
    }
    private async Task<string> PostRequest(string url, Dictionary<string, string> formData)
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

            // 打印响应内容
            // Debug.Log(responseBody);
            return responseBody;
        }
    }
}