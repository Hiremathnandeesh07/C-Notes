using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_On_ProductsTable_ParameterizedQueries.Models
{
     public class TableProducts

        {
        public TableProducts( string name, string category, decimal price)
        {
           
            Name = name;
            Category = category;
            Price = price;
        }

                
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
        }
    
}
