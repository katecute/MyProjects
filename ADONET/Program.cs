using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication20
{
    class Program
    {
        static void Main(string[] args)
        {
            var setting = new ConnectionStringSettings
            {
                Name = "ConnectionString1",
                ConnectionString = @"Data Source=ELROND\SQLEXPRESS;
                                     Initial Catalog=Testdb;
                                     Integrated Security=True;"
            };

            Configuration myconfig;

            myconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            myconfig.ConnectionStrings.ConnectionStrings.Add(setting);
            myconfig.Save();

            SqlConnection connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            connection.Open();

            SqlCommand comd = new SqlCommand();
            comd = connection.CreateCommand();

            comd.Transaction = connection.BeginTransaction(IsolationLevel.Serializable);

            //comd.CommandText = "DELETE FROM dbo.Products WHERE Price > 20000";

            comd.CommandText = "INSERT INTO Products VALUES('657365', 'MacBook Pro', '47500', 'on')";

            comd.ExecuteNonQuery();

            comd.Transaction.Commit();

            Console.WriteLine("Transaction commited.");
        }
    }
}
