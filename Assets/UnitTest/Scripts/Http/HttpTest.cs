using System.Net;
using UnityEngine;

public class HttpTest : MonoBehaviour
{
    private void Start()
    {
        HttpClientMrg.Instance.DownLoadFile("测试文件.txt", Application.persistentDataPath + "/测试文件.txt", (code) =>
        {
            Debug.Log(code);
            if (code == HttpStatusCode.OK)
            {
                Debug.Log("下载成功");
            }

        });
    }
}