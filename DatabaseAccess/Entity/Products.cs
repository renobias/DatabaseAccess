using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace DatabaseAkses.Entity
{
    [TableName("Products")]
    [PrimaryKey("ProductID")]
    [ExplicitColumns]
    [Serializable]
    class Products
    {
        [Column]
        public string ProductID { get; set; }
        [Column]
        public string ProductName { get; set; }
        [Column]
        public string SupplierID { get; set; }
        [Column]
        public string CategoryID { get; set; }
        [Column]
        public string QuantityPerUnit { get; set; }
        [Column]
        public string UnitPrice { get; set; }
        [Column]
        public string UnitsInStock { get; set; }
        [Column]
        public string UnitsOnOrder { get; set; }
        [Column]
        public string ReorderLevel { get; set; }
        [Column]
        public string Discontinued { get; set; }

    }
}
