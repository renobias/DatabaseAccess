using IntroPetapoco.Entity;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntroPetapoco
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> list = Customer.Fetch(new Sql());
            foreach (var c in list)
            {
                Console.WriteLine("Customer ID: {0} Company Name: {1}", c.CustomerID, c.CompanyName);
            }

            Console.WriteLine("Masukkan ID Customer : ");
            string cusID = Console.ReadLine();
            Customer cus = Customer.FirstOrDefault(new Sql().Where("CustomerID = @0", cusID));
            if(cus==null)
            {
                Console.WriteLine("data not found");
            }
            else
            {
                Console.WriteLine("Customer ID: {0,-10}, Company Name : {1}", cus.CustomerID, cus.CompanyName);
            }


            /**
            Console.Write("Masukkan ID Customer : ");
            string cusID = Console.ReadLine();

            Customer cus = Customer.FirstOrDefault(new Sql().Where("CustomerID = @0 ", cusID));
            if(cus==null)
            {
                Console.WriteLine("Data Not Foound!");
            }
            else
            {
                Console.WriteLine("CustomerID : {0,-10} Company Name: {1}",cus.CustomerID,cus.CompanyName);
            }

            try
            {
                Customer newCus = new Customer();
                newCus.CustomerID = "AABKI";
                newCus.CompanyName = "PT. Segar Selalu";
                newCus.ContactName = "Nanda";
                Console.WriteLine("Insert Data Success");
            }catch(Exception ex)
            {
                Console.WriteLine("Insert Error: {0}", ex.Message);
            }
    */
            Console.ReadKey();
        }

        //PAGING
        public Page<Customer> GetPage(int page, int pageSize, Dictionary<string, object> param)
        {
            string sql = " 1=1 ";
            int i = 0;
            var args = new object[param.Count];
            foreach (string key in param.Keys)
            {
                sql += string.Format(" AND {0} LIKE @{1}", key, i);
                args[i] = string.Format("%{0}%", param[key]);
                i++;
            }
            return Customer.Page(page, pageSize, new Sql().Where(sql, args));
        }

        public List<Customer> GetListCustomers()
        {
            return Customer.Fetch(new Sql());
        }

        public Customer GetCustomerByID(string id)
        {
            return Customer.FirstOrDefault(new Sql().Where("CustomerID =@0", id));
        }

        public List<CustOrderHist> GetCustOrderHist(string id)
        {
            var DB = new NORTHWINDDB
        }
    }
}
