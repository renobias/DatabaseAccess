using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            BarangCRUD objBarangCRUD = new BarangCRUD();
            bool exist = objBarangCRUD.IsBarangExistInSupplier(1);
            if (exist == true)
            {
                Console.WriteLine("Hasil Method 1 : Barang Ada");
            }
            else
            {
                Console.WriteLine("Hasil Method 1 : Barang Tidak ada");
            }

            decimal totalharga = objBarangCRUD.GetTotalHargaByKaegori(1);
            Console.WriteLine("\nHasil Method 2");
            Console.WriteLine("Total Harga : {0}",totalharga);

            bool existprocedure = objBarangCRUD.IsBarangExistInSupplierProcedure(1);
            if (exist == true)
            {
                Console.WriteLine("Hasil Method 3 : Barang Ada");
            }
            else
            {
                Console.WriteLine("Hasil Method 3 : Barang Tidak ada");
            }

            /**
            bool stat = false;
            string msg = "";
            var crud = new BarangCRUD();
            List<Barang> list = crud.GetAll();
            BarangCRUD objBarangCRUD = new BarangCRUD();
            Barang objBarang = new Barang(2, "Sabun", 1, 1, 3200, 1);
            objBarangCRUD.Insert(objBarang,out stat,out msg);
            Console.WriteLine(list);

            foreach (var b in list)
            {
                Console.WriteLine("{0,-6}{1,-6}",b.ID,b.NamaBarang);
            }
            /**
            foreach (List<BarangCRUD> l  in list)
            {
                Console.WriteLine(l);
            }
            */

            /**
            Barang barang = crud.GetById(1);
            
            foreach(var bid in list)
            {
                Console.WriteLine("{0,-6} {1,-6}",bid.ID,bid.NamaBarang);
            }
    */

            Console.ReadKey();
        }
    }
}
