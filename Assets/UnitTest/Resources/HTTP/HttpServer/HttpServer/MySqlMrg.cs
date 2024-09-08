using System;
using MySql.Data.MySqlClient;

class MySqlMrg
{
    private string connectionString = "server=112.124.22.247;port=3306;user=root;password=dulin1215;database=UserData";
    private MySqlConnection mConnection = null;
    private MySqlConnection Connection
    {
        get
        {
            if (mConnection == null)
            {
                // 创建 MySQL 连接对象
                mConnection = new MySqlConnection(connectionString);
                try
                {
                    // 打开数据库连接
                    mConnection.Open();
                    // 查询数据
                    // string queryStr = "Select * from UserInfo where account=\"1528449507\"";

                    // string insertStr = "INSERT INTO `UserInfo` (`id`, `account`, `password`) VALUES (DEFAULT, \"1234\", \"1234\")";
                    // InsertData(connection, insertStr);

                    // 更新数据
                    // UpdateData(connection);

                    // // 删除数据
                    // DeleteData(connection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return mConnection;
        }
        set
        {
            mConnection = value;
        }
    }
    public static MySqlMrg Instance
    {
        get
        {
            if (minstance == null)
            {
                minstance = new MySqlMrg();
            }
            return minstance;
        }
    }
    private static MySqlMrg minstance = null;

    // static void Main()
    // {
    //     string connectionString = "server=112.124.22.247;port=3306;user=root;password=dulin1215;database=UserData";

    //     // 创建 MySQL 连接对象
    //     MySqlConnection connection = new MySqlConnection(connectionString);

    //     try
    //     {
    //         // 打开数据库连接
    //         connection.Open();

    //         // 插入数据
    //         // InsertData(connection);

    //         // 查询数据
    //         string queryStr = "Select * from UserInfo where account=\"1528449507\"";
    //         // QueryData(connection, queryStr, (reader) =>
    //         // {
    //         //     int accountIndex = reader.GetOrdinal("account");
    //         //     //通过序号获取值
    //         //     string account = reader.GetString(accountIndex);
    //         //     Console.WriteLine(account.GetType());
    //         //     Console.WriteLine(account);
    //         // });
    //         string insertStr = "INSERT INTO `UserInfo` (`id`, `account`, `password`) VALUES (DEFAULT, \"1234\", \"1234\")";
    //         InsertData(connection, insertStr);

    //         // 更新数据
    //         // UpdateData(connection);

    //         // // 删除数据
    //         // DeleteData(connection);
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine("Error: " + ex.Message);
    //     }
    //     finally
    //     {
    //         // 关闭数据库连接
    //         connection.Close();
    //     }
    // }

    public int InsertData(string insertStr)
    {
        // string insertQuery = "INSERT INTO your_table (column1, column2) VALUES (@value1, @value2)";
        MySqlCommand command = new MySqlCommand(insertStr, Connection);
        // command.Parameters.AddWithValue("@value1", "value1");
        // command.Parameters.AddWithValue("@value2", "value2");

        int rowsAffected = command.ExecuteNonQuery();
        Console.WriteLine($"{rowsAffected} rows inserted.");
        return rowsAffected;
    }

    public void QueryData(string queryStr, Action<MySqlDataReader> action)
    {
        Console.WriteLine(Connection);
        MySqlCommand command = new MySqlCommand(queryStr, Connection);

        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                //数据读取方法
                //确定要读取的列名获取其对应序号
                // int accountIndex = reader.GetOrdinal("account");
                // //通过序号获取值
                // string account = reader.GetString(accountIndex);
                // Console.WriteLine(account.GetType());
                // Console.WriteLine(account);

                // //方法二直接获取
                // //需要自己转换类型
                // string account_2 = reader["account"] as string;
                // Console.WriteLine(account_2);

                // string account_3 = reader.GetValue(1) as string;
                // object[] temp = new object[reader.FieldCount];
                // reader.GetValues(temp);
                // Console.WriteLine(account_3);


                // string account_4 = temp[accountIndex] as string;
                // Console.WriteLine(account_4);

                action(reader);
            }
        }
    }

    // static void UpdateData(MySqlConnection connection)
    // {
    //     string updateQuery = "UPDATE your_table SET column1 = @newValue WHERE column2 = @searchValue";

    //     MySqlCommand command = new MySqlCommand(updateQuery, connection);
    //     command.Parameters.AddWithValue("@newValue", "new_value");
    //     command.Parameters.AddWithValue("@searchValue", "value2");

    //     int rowsAffected = command.ExecuteNonQuery();
    //     Console.WriteLine($"{rowsAffected} rows updated.");
    // }

    // static void DeleteData(MySqlConnection connection)
    // {
    //     string deleteQuery = "DELETE FROM your_table WHERE column2 = @value";

    //     MySqlCommand command = new MySqlCommand(deleteQuery, connection);
    //     command.Parameters.AddWithValue("@value", "value2");

    //     int rowsAffected = command.ExecuteNonQuery();
    //     Console.WriteLine($"{rowsAffected} rows deleted.");
    // }
}

