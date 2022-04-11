using System;
using System.Data;
using System.Data.SqlClient;

namespace Generics
{
    class Program
    {
        static void Main()
        {
            var intClass = new GetValue<int>
            {
                Value = 20
            };

            var stringClass = new GetValue<string>()
            {
                Value = "Test"
            };

            intClass.PrintValue("Integer", intClass.Value);
            stringClass.PrintValue("String", stringClass.Value);

            Console.ReadKey();
        }
        
        public int Student(string firstName)
        {
            string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=..\\CodeQLDB.mdf;Integrated Security=True";
            var con = new SqlConnection(str);
            var cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Student(FirstName) " +
                                "VALUES(" + firstName + ")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();

            var rowsUpdated = cmd.ExecuteNonQuery();

            con.Close();

            return rowsUpdated;
        }
    }

    internal class GetValue<T>
    {
        private T _data;

        public T Value
        {
            get => _data;
            set => _data = value;
        }

        public void PrintValue<TYpeOfValue>(string msg, TYpeOfValue val)
        {
            Console.WriteLine($"Message: {msg} and Value: {val}");
        }
    }
}
