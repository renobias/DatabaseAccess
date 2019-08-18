using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    class KategoriBarangCRUD
    {
        string constr;
        public KategoriBarangCRUD()
        {
            constr = ConfigurationManager.ConnectionStrings["PROCUREMENT"].ConnectionString;
        }

        public List<KategoriBarang> getAll()
        {
            List<KategoriBarang> list = new List<KategoriBarang>();
            using(var conn = new SqlConnection(constr))
            {
                conn.Open();
                string query = "SELECT*FROM Kategori";
                SqlCommand cmd = new SqlCommand(query,conn);
                SqlDataReader reader = cmd.ExecuteReader();
                KategoriBarang KB = null;
                while (reader.Read())
                {
                    list.Add(KB);
                }
                conn.Close();
            }
            return list;
        }

        public KategoriBarang GetById(int id)
        {
            KategoriBarang kategoribarang = null;
            using (var conn = new SqlConnection(constr))
            {
                conn.Open();
                String query = "SELECT*FROM KategoriBarang where ID=@0";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@0", id);
                SqlDataReader reader = cmd.ExecuteReader();
                KategoriBarang kb = null;
                while (reader.Read())
                {
                    kb = new KategoriBarang(reader);
                }
            }
            return kategoribarang;
        }

        public void insert(KategoriBarang KategoriBarang,out bool status,out string message)
        {
            try
            {
                using (var conn = new SqlConnection(constr))
                {
                    conn.Open();
                    string query = "INSERT INTO KATEGORI(NamaKategori,Status) VALUES(@0,@1,@2)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@0",KategoriBarang.NamaKategori);
                    cmd.Parameters.AddWithValue("@0", KategoriBarang.Status);
                    int row = cmd.ExecuteNonQuery();
                    status = row > 0;
                    message = "insert kategori barang success";
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                status = false;
                message = "Insert barang failed " + e.Message;
            }
        }

        public void update(KategoriBarang KategoriBarang, out bool status, out string message)
        {
            try
            {
                using (var conn = new SqlConnection(constr))
                {
                    conn.Open();
                    string query = "INSERT INTO KATEGORI(NamaKategori,Status) VALUES(@0,@1,@2)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@0", KategoriBarang.NamaKategori);
                    cmd.Parameters.AddWithValue("@0", KategoriBarang.Status);
                    int row = cmd.ExecuteNonQuery();
                    status = row > 0;
                    message = "insert kategori barang success";
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                status = false;
                message = "Insert barang failed " + e.Message;
            }
        }

        public void delete(int id, out bool status, out string message)
        {
            try
            {
                using (var conn = new SqlConnection(constr))
                {
                    conn.Open();
                    string query = @"DELETE FROM KategoriBarang where ID=@0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@0", id);
                    int row = cmd.ExecuteNonQuery();
                    status = row > 0;
                    message = "Delete kategori barang success";
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                status = false; 
                message = "Delete kategori barang failed " + ex.Message;
            }
        }
    }
}
