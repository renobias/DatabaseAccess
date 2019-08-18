using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using DatabaseAkses.Entity;

namespace DatabaseAkses.CRUD
{
    class CustomersCRUD
    {
        private Database DB = null;
        public CustomersCRUD()
        {
            DB = new Database("NORTHWIND");
        }

        public List<Customers> GetAll()
        {
            var list = DB.Fetch<Customers>(new Sql().Where("1=1"));
            return list;
        }

        public Customers GetByID(string id)
        {
            var cus = DB.FirstOrDefault<Customers>(new Sql().Where("CustomerID=@0", id));
            return cus;
        }

        public void Insert(Customers cus, out bool status, out string message)
        {
            status = false;
            message = "";
            try {
                DB.Insert("Customers", "CustomerID", false, cus);
                status = true;
            }
            catch (Exception e)
            {
                status = false;
                message = e.Message;
            }
    
        }
        public void Update(Customers cus, out bool status, out string message)
        {
            status = false;
            message = "";
            DB.Update("Customers", "CustomerID", cus);
        }
        public void Delete(Customers cus, out bool status, out string message)
        {
            status = false;
            message = "";
            DB.Delete("Customers", "CustomerID", cus);
        }

        public int GetJumlahCustomerByID(int id)
        {
            string sql = @"SELECT COUNT(*) FROM Customers WHERE CustomerID LIKE @0";
            int jml = DB.ExecuteScalar<int>(sql, "&" + id + "%");
            return jml;
        }
    }
}
