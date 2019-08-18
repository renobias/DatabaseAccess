using IntroEF.Context;
using IntroEF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;



namespace IntroEF
{
    public class Program
    {
        static void Main(string[] args)
        {
            var prog = new Program();
            var context = new NorthwindContext();
            //goto detail;
            ulang:
            Console.Write("Masukan halaman: ");
            int p = Convert.ToInt32(Console.ReadLine());
            var param = new Dictionary<string, object>();
            param["CustomerID"] = "AL";
            param["CompanyName"] = "G";
            var list = prog.GetPage(p, 10, param);
            Console.WriteLine("{0, -15} {1, -40} {2}", "Customer ID", "Company Name", "Contact Name");
            Console.WriteLine("============================================================================");
            foreach (var c in list)
            {
                Console.WriteLine("{0, -15} {1, -40} {2}", c.CustomerID, c.CompanyName, c.ContactName);
            }

            goto ulang;
            Console.Write("Masukan Customer ID: ");
            var id = Console.ReadLine();
            var cus = context.Customers.FirstOrDefault(c => c.CustomerID.Equals(id));
            Console.WriteLine("{0, -15} {1, -40} {2}", cus.CustomerID, cus.CompanyName, cus.ContactName);

            //cus = new Customers();
            //cus.CustomerID = "AABCA";
            //cus.CompanyName = "PT. CodeLinko Indonesia";
            //context.Customers.Add(cus);
            //context.SaveChanges();
            context.Customers.Remove(cus);
            context.SaveChanges();
            detail:
            Console.ReadKey();
        }

        public Customers GetByID(string id)
        {
            var context = new NorthwindContext();
            return context.Customers.FirstOrDefault(c => c.CustomerID.Equals(id));
        }

        public List<Customers> GetPage(int page, int pageSize)
        {
            var context = new NorthwindContext();
            return context.Customers
                .Where(" CustomerID.Contains(@0)", "AL")
                .OrderBy(c => c.CustomerID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
        }

        public List<Customers> GetPage(int page, int pageSize, Dictionary<string, object> param)
        {
            var context = new NorthwindContext();
            string where = " 1=1 ";
            int i = 0;
            var args = new object[param.Count];
            foreach (string key in param.Keys)
            {
                where += string.Format(" AND {0}.Contains(@{1})", key, i);
                args[i] = param[key];
                i++;
            }
            return context.Customers
                .Where(where, args)
                .OrderBy(c => c.CustomerID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
        }
    }
}
