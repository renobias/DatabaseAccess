using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    class Barang
    {
        public int ID { get; set; }
        public string NamaBarang { get; set; }
        public int Kategori { get; set; }
        public int Supplier { get; set; }
        public decimal Harga { get; set; }
        public int Status { get; set; }

        public Barang() { }

        public Barang(int id,string nama,int kategori, int supplier, decimal harga, int status)
        {
            ID = id;
            NamaBarang = nama;
            Kategori = kategori;
            Supplier = supplier;
            Harga = harga;
            Status = status;
        }

        public Barang(SqlDataReader reader)
        {
            ID = reader.GetInt32(0);
            NamaBarang = reader.GetString(1);
            Kategori = reader.GetInt32(2);
            Supplier = reader.GetInt32(3);
            Harga = reader.GetDecimal(4);
            Status = reader.GetInt32(5);
        }
    }
}
