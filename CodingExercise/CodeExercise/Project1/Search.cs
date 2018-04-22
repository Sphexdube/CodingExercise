using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project1
{
    public class Search
    {
        SqlConnection _connection;
        SqlCommand _command;
        SqlDataReader _dataReader;
        DataTable dataTable;

        public Search(string connString)
        {
            _connection = new SqlConnection(connString);
        }

        public void searchItem()
        {
            try
            {
                _connection.Open();

                string search = String.Empty;
                List<string> result = new List<string>();

                Console.WriteLine("Enter item: ");
                search = Console.ReadLine();

                bool containsnum = Regex.IsMatch(search, @"\d");

                if (!containsnum && search != null)
                {
                    var query = "select * from ItemDesc where Description LIKE '%" + search + "%'";
                    _command = new SqlCommand(query, _connection);
                    _dataReader = _command.ExecuteReader();

                    dataTable = new DataTable();
                    dataTable.Load(_dataReader);

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            result.Add(dataTable.Rows[i].ItemArray[1].ToString());
                        }
                        Console.WriteLine("\nMatching Item(s): \n" + string.Join("\n", result.Cast<string>().ToArray()));
                    }
                    else
                    {
                        Console.WriteLine("\nNo Matching Items!");
                    }
                    Console.Write("\nPress [Enter] to Exit");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("Search input is invalid!");
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
