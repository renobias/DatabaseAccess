using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    class KategoriBarang
    {
        public int ID{get;set;}
        public string NamaKategori { get; set; }
        public int Status { get; set; }

        public KategoriBarang()
        {}

        public KategoriBarang(int id, string namakategori, int status)
        {
            ID = id;
            NamaKategori = namakategori;
            Status = status;
        }

        public KategoriBarang(SqlDataReader reader)
        {
            ID = reader.GetInt32(0);
            NamaKategori = reader.GetString(1);
            Status = reader.GetInt32(2);
            Status = reader.GetInt32(3);
        }
    }
}
