using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project2
{
    public class Employee
    {
        SqlConnection _connection;
        SqlCommand _command;
        SqlDataReader _dataReader;
        DataTable dataTable;
        public Employee(string connString)
        {
            _connection = new SqlConnection(connString);
        }
        public void retrieveEmployees() 
        {
            try
            {
                 _connection.Open();

                string name = String.Empty;
                List<string> result = new List<string>();

                Console.WriteLine("Enter name: ");
                name = Console.ReadLine();

                bool containsnum = Regex.IsMatch(name, @"\d");

                if (!containsnum && name != null)
                {
                    var query = "SELECT * FROM dbo.GetEmployees('" + name +"')";
                    _command = new SqlCommand(query, _connection);
                    _dataReader = _command.ExecuteReader();

                    dataTable = new DataTable();
                    dataTable.Load(_dataReader);

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            result.Add(dataTable.Rows[i].ItemArray[0].ToString());
                        }
                        Console.WriteLine("\nEmployee(s) report to " + name + ": \n" + string.Join("\n", result.Cast<string>().ToArray()));
                    }
                    else
                    {
                        Console.WriteLine("\nNo Employee(s) Found!");
                    }
                    Console.Write("\nPress [Enter] to Exit");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("Input was invalid!");
                    Console.Write("Press [Enter] to Exit");
                    Console.ReadLine();
                }

                _command.Dispose();
                _connection.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
