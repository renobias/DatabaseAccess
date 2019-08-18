using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using DatabaseAkses.CRUD;
using DatabaseAkses.Entity;

namespace DatabaseAkses.CRUD
{
    class PetapocoInAction
    {
        public static void Main(string[] a)
        {
            CustomersCRUD crud = new CustomersCRUD();

            var cus = crud.GetByID("ALFKI");
            Console.WriteLine("Company Name : {0}, ContactName : {1}", cus.CompanyName, cus.ContactName);

            cus.CustomerID = "ALFKI";
            cus.CompanyName = "PT.ASHIAP";
            bool status; string msg;


            //update
            crud.Update(cus, out status, out msg);
            ////delete
            //crud.Delete(cus, out status, out msg);
            ////insert
           crud.Insert(cus, out status, out msg);
            Console.ReadKey();

        }
    }
}
