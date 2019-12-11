using System;
using System.Data.Odbc;

using System.Data.SqlClient;

namespace ConsoleDBConnApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OdbcConnection DbConnection = new OdbcConnection("DSN=odbc17;UID=sa;PWD=dbpwd1");
            DbConnection.Open();
            OdbcCommand DbCommand = DbConnection.CreateCommand();
            DbCommand.CommandText = "SELECT * FROM test_tab";
            OdbcDataReader DbReader = DbCommand.ExecuteReader();

            int fCount = DbReader.FieldCount;
            Console.Write(":");
            for (int i = 0; i < fCount; i++)
            {
                String fName = DbReader.GetName(i);
                Console.Write(fName + ":");
            }
            Console.WriteLine();


            while (DbReader.Read())
            {
                Console.Write(":");
                for (int i = 0; i < fCount; i++)
                {
                    String col = DbReader.GetString(i);

                    Console.Write(col + ":");
                }
                Console.WriteLine();
            }

            DbReader.Close();
            DbCommand.Dispose();
            DbConnection.Close();







        }
    }
}
