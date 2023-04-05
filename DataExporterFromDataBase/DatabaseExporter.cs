using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExporterFromDataBase
{
    internal class DatabaseExporter
    {
       public static List<Category> ExportDataBase(string path)
        {
            HashSet<Category> categories = new HashSet<Category>();
            using SqlConnection conn = new SqlConnection(path);
            using SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType=CommandType.Text;
            cmd.CommandText = "select c.CategoryID, c.CategoryName, p.ProductID, p.ProductName, p.UnitPrice from Categories as c left join Products as p on p.CategoryID=c.CategoryID";

            cmd.Connection = conn;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            
            while (reader.Read())
            {
               
                categories.Add(new Category
                {
                    Id = Convert.ToInt32(reader["CategoryID"]),
                    CategoryName = reader["CategoryName"].ToString(),
                });

                var tt = Convert.ToInt32(reader["CategoryID"]);
                int index = categories.FindIndex(c => c.Id == tt);

                categories[index].Products.Add(
                                        new Product
                                        {
                                            Id = Convert.ToInt32(reader["ProductID"]),
                                            ProductName = reader["ProductName"].ToString(),
                                            Price = Convert.ToDecimal(reader["UnitPrice"])
                                        });


            }


            return categories;
       }
      
    }
}
