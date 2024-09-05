using System.Data;
using UnityEngine;
using MySql;
using MySql.Data.MySqlClient;
public class TestSql : MonoBehaviour
{
    public string host = "172.22.5.83";
    public string port = "3306";
    public string username = "root";
    public string pwd = "123";
    public string database = "egg";
    void Start()
    {
        SqlAccess sql = new SqlAccess(host, port, username, pwd, database);
        // string sqlString = "INSERT INTO egg.eggs_record VALUES (DEFAULT, '龙蛋', NULL)";
        // SqlAccess.ExecuteQuery(sqlString);
        string str = "SELECT * FROM UserInfo;";
        MySqlCommand com = new MySqlCommand(str, SqlAccess.dbConnection);//将指令和连接数据库类关联
        MySqlDataReader read = com.ExecuteReader();//获取数据库该表的数据
        while (read.Read())
        {
            //Debug.Log(read[0].ToString());//可以获取表信息
            Debug.Log(read["account"]);
        }
        read.Close();
    }
}
