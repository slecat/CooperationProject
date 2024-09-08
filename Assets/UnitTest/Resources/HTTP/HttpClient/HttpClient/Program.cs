// See https://aka.ms/new-console-template for more information
using SimpleHttpClient;

Console.WriteLine("Hello, World!");

string url = "http://112.124.22.247:8888/";
//将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
// string getJson = HttpUitls.Get(url);
string data = "account=1528449507&password=dulin1215";
string getJson = HttpUitls.Post(url, data, "");
Console.Write(getJson);

// string[] keys = { "account", "password" };
// string query = "select " + keys.Select(k => k + " ") + "from" + ""