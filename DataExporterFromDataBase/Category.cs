using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExporterFromDataBase
{
    internal class Category
    {
        private string _categoryCode = "";
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string CategoryCode { get; set;}
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
