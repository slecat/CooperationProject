// See https://aka.ms/new-console-template for more information
using SimpleHttpServer;

// Console.WriteLine("Hello, World!");
HttpServer httpServer;
if (args.GetLength(0) > 0)
{
    httpServer = new MyHttpServer(Convert.ToInt16(args[0]));
}
else
{
    httpServer = new MyHttpServer(8888);
}
Thread thread = new Thread(new ThreadStart(httpServer.listen));
thread.Start();
string queryStr = "Select * from UserInfo where account=\"1528449507\"";
MySqlMrg.Instance.QueryData(queryStr, (reader) =>
{
    int accountIndex = reader.GetOrdinal("account");
    //通过序号获取值
    string account = reader.GetString(accountIndex);
    Console.WriteLine(account.GetType());
    Console.WriteLine(account);
});