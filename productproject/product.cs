using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WpfApp1
{
    public class Product
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string productname { get; set; }
        public decimal productPrice { get; set; }

    }
}