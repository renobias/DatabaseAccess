using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    class BarangCRUD
    {
        string constr;
        public BarangCRUD()
        {
            constr = ConfigurationManager.ConnectionStrings["PROCUREMENT"].ConnectionString;
        }

        public List<Barang> GetAll()
        {
            List<Barang> list = new List<Barang>();
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = "SELECT * FROM BARANG";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                Barang b = null;
                while (reader.Read())
                {
                    b = new Barang(reader);
                    list.Add(b);
                }
                conn.Close();
            }
            return list;
        }

        public Barang GetById(int id)
        {
            Barang barang = null;
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = "SELECT * FROM BARANG WHERE ID=@0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@0", id);
                SqlDataReader reader = cmd.ExecuteReader();
                Barang b = null;
                while (reader.Read())
                {
                    barang = new Barang(reader);
                }
                conn.Close();
            }
            return barang;
        }


        public void Insert(Barang barang,out bool status,out string message)
        {
            try {
                using (var conn = new SqlConnection(constr))
                {
                    conn.Open();
                    string query = "INSERT INTO BARANG(NamaBarang,Kategori,Supplier,Harga,Status) VALUES (@0,@1,@2,@3,@4)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@0", barang.NamaBarang);
                    cmd.Parameters.AddWithValue("@1", barang.Kategori);
                    cmd.Parameters.AddWithValue("@2", barang.Supplier);
                    cmd.Parameters.AddWithValue("@3", barang.Harga);
                    cmd.Parameters.AddWithValue("@4", barang.Status);
                    int row = cmd.ExecuteNonQuery();
                    status = row > 0;
                    message = "insert barang success";
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                status = false;
                message = "Insert barang failed "+ex.Message;
            }
        }

        public void Update(Barang barang, out bool status, out string message)
        {
            try
            {
                using (var conn = new SqlConnection(constr))
                {
                    conn.Open();
                    string query = @"UPDATE BARANG SET NamaBarang=@0,Kategori=@1,Supplier=@2,Harga=@3,Status=@4 where ID=@5";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@0", barang.NamaBarang);
                    cmd.Parameters.AddWithValue("@1", barang.Kategori);
                    cmd.Parameters.AddWithValue("@2", barang.Supplier);
                    cmd.Parameters.AddWithValue("@3", barang.Harga);
                    cmd.Parameters.AddWithValue("@4", barang.Status);
                    cmd.Parameters.AddWithValue("@5", barang.ID);
                    int row = cmd.ExecuteNonQuery();
                    status = row > 0;
                    message = "update barang success";
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                status = false;
                message = "Insert barang failed " + ex.Message;
            }
        }

        public void delete(int id, out bool status, out string message)
        {
            try
            {
                using (var conn = new SqlConnection(constr))
                {
                    conn.Open();
                    string query = @"DELETE FROM BARANG where ID=@0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@0", id);
                    int row = cmd.ExecuteNonQuery();
                    status = row > 0;
                    message = "Delete barang success";
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                status = false;
                message = "Delete barang failed " + ex.Message;
            }
        }

        public bool IsSupplierExistInAlamat(string alamat)
        {
            bool exist = false;
            using (var conn = new SqlConnection(constr))
            {
                string query = "IF EXISTS (SELECT 1 FROM Supllier WHERE Alamat LIKE @0) SELECT 1[Hasil] ELSE SELECT 0[Hasil]";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@0", alamat + "%");
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    exist = Convert.ToBoolean(result);
                }
            }
            return exist;
        }

        public string GetNamaKategoriByID(int id)
        {
            string nama = "";
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = "SELECT NamaKategori FROM Kategori WHERE ID=@0";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@0",id);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    nama = Convert.ToString(result);
                }
                conn.Close();
            }
            return nama;
        }

        public List<Barang> getal()
        {
            List<Barang> list = new List<Barang>();
            using(var conn = new SqlConnection(constr)){
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                string query = "select*from barang";
                SqlDataReader reader = cmd.ExecuteReader();
                Barang b = null;
                while (reader.Read())
                {
                    b = new Barang(reader);
                    list.Add(b);
                }
                conn.Close();
            }
            return list;
        }

        public List<Barang> GetBarangByName(string nama)
        {
            List<Barang> list = new List<Barang>();
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = "EXEC PROC_GetBarangByName @0";
                SqlCommand cmd = new SqlCommand(query, conn);
                
                
                conn.Close();
            }
            return list;
        }

        public decimal GetJumlahBarangByRangeHarga(decimal start,decimal end)
        {
            int jumlah = 0;
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = @"SELECT dbo.FUNC_CountBarangByRangeHarga(@0,@1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@0", start);
                cmd.Parameters.AddWithValue("@1", end);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    jumlah = Convert.ToInt32(result);
                }
                conn.Close();
            }
            return jumlah;
        }

        //1
        public bool IsBarangExistInSupplier(int supplier)
        {
            bool exist = false;
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = "IF EXISTS (SELECT * FROM Barang WHERE Supplier LIKE @0) SELECT 1[Hasil] ELSE SELECT 0[Hasil]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@0", supplier + "%");
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    exist = Convert.ToBoolean(result);
                }
            }
            return exist;
        }

        //2
        public decimal GetTotalHargaByKaegori(decimal kategori)
        {
            decimal TotalHarga = 0;
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = @"SELECT SUM(Harga) as Total from BARANG WHERE Kategori=@0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@0", kategori);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    TotalHarga = Convert.ToDecimal(result);
                }
                conn.Close();
            }
            return TotalHarga;
        }

        //3
        public bool IsBarangExistInSupplierProcedure(int supplier)
        {
            bool exist = false;
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = "EXEC PROC_BarangExistInSupplierrrrr @0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@0", supplier);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    exist = Convert.ToBoolean(result);
                }
            }
            return exist;
        }

        //4

    }
}
