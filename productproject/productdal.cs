using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    public class Productdal
    {
        SqlConnection _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductCustomerDatabase;Integrated Security=True;");
        public List<Product> _TakeProduct()
        {
            CheckConnection();
            SqlCommand command = new SqlCommand("select * from ProductTable", _connection);
            SqlDataReader Reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (Reader.Read())
            {
                Product product = new Product()
                {

                    CustomerId = Convert.ToInt32(Reader[0]),
                    CustomerName = Reader[1].ToString(),
                    productname = Reader[2].ToString(),
                    productPrice = Convert.ToDecimal(Reader[3])
                };
                products.Add(product);
            }
            Reader.Close();
            _connection.Close();
            return products;
        }
        public void Add(Product product)
        {
            CheckConnection();
            SqlCommand command = new SqlCommand("insert into ProductTable values(@cname,@productname,@productprice)", _connection);
            command.Parameters.AddWithValue("@cname", product.CustomerName);
            command.Parameters.AddWithValue("@productname", product.productname);
            command.Parameters.AddWithValue("@productprice", product.productPrice);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Update(Product product)
        {
            CheckConnection();
            SqlCommand command = new SqlCommand("Update ProductTable set CustomerName=@cname,productname=@productname,productPrice=@productprice where CustomerId=@ID", _connection);
            command.Parameters.AddWithValue("@ID", product.CustomerId);
            command.Parameters.AddWithValue("@cname", product.CustomerName);
            command.Parameters.AddWithValue("@productname", product.productname);
            command.Parameters.AddWithValue("@productprice", product.productPrice);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Delete(int id)
        {
            CheckConnection();
            SqlCommand command = new SqlCommand("Delete from ProductTable  where CustomerId=@ID", _connection);
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void CheckConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

    }
}