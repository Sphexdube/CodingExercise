using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        public static string connectionString = "Data Source=SIPHESIHLE-DUBE;Initial Catalog=AdaptIT;Integrated Security=True";

        static void Main(string[] args)
        {
            Employee emp = new Employee(connectionString);
            emp.retrieveEmployees();
        }
    }
}
