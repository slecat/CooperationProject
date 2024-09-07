// See https://aka.ms/new-console-template for more information
using SimpleHttpClient;

Console.WriteLine("Hello, World!");

string url = "http://localhost:8888/";
//将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
string getJson = HttpUitls.Get(url);
Console.Write(getJson);
//JsonConvert.SerializeObject(listjson);
//JSON.parse(json);
Console.ReadKey();
