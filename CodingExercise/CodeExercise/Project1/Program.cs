using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        public static string connectionString = "Data Source=SIPHESIHLE-DUBE;Initial Catalog=AdaptIT;Integrated Security=True";
 
        static void Main(string[] args)
        {
            Search search = new Search(connectionString);
            search.searchItem();
        }
    }
}
