using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    class Supplier
    {
        public int ID { get; set; }
        public string NamaSupplier { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
        public string Telepon { get; set; }
        public string Kontak { get; set; }

        public Supplier() { }

        public Supplier(int id, string namasupplier, string alamat, string email, string telepon, string kontak)
        {
            ID = id;
            NamaSupplier = namasupplier;
            Alamat = alamat;
            Email = email;
            Telepon = telepon;
            Kontak = kontak;
        }

        public Supplier(SqlDataReader reader)
        {
            ID = reader.GetInt32(0);
            NamaSupplier = reader.GetString(1);
            Alamat = reader.GetString(2);
            Email = reader.GetString(3);
            Telepon = reader.GetString(4);
            Kontak = reader.GetString(5);
        }
    }
}
