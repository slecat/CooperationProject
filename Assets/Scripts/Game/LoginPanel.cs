using UnityEngine;
using QFramework;
using MySql.Data.MySqlClient;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace QFramework.Example
{
	public partial class LoginPanel : ViewController
	{
        private string host = "112.124.22.247";
        private string port = "3306";
        private string username = "root";
        private string pwd = "dulin1215";
        private string database = "UserData";

        private string Account_Str;
		private string Password_Str;
		void Start()
		{
            BtnLogin.onClick.AddListener(() =>
            {
                Account_Str = Account.text;
                Password_Str = Password.text;

                Lianjie(Account_Str,Password_Str);
            });
		}

        private void Lianjie(string account_t,string password_t)
        {
            print("btn");
            SqlAccess sql = new SqlAccess(host, port, username, pwd, database);
            string str = $"SELECT password\r\nFROM UserInfo\r\nWHERE `account` = \"{account_t}\";";
            MySqlCommand com = new MySqlCommand(str, SqlAccess.dbConnection);//将指令和连接数据库类关联
            MySqlDataReader read = com.ExecuteReader();//获取数据库该表的数据
            if (read.Read())
            {
                //Debug.Log(read[0].ToString());//可以获取表信息
                print(read["password"].ToString());
                if (password_t == read["password"].ToString())
                {
                    Debug.Log("登龙成功");
                }
                else
                {
                    Debug.Log("登龙失败");
                } 
            }
            else
            {
                Debug.Log("账号不存在");
            }
            read.Close();
        }
    }
}
