using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Meeting_Organizer
{
    public class dbConn
    {
        private SqlConnection _conn;
        public dbConn()
        {

        }

        public SqlConnection conn()
        {
            System.Configuration.ConnectionStringsSection css = (System.Configuration.ConnectionStringsSection)System.Configuration.ConfigurationManager.GetSection("connectionStrings");
            _conn = new SqlConnection(css.ConnectionStrings["dbConn"].ConnectionString);
            return _conn;
        }
    }
    public class data
    {
    }

    public class Toplanti
    {
        public DataSet Kayit(string baslik, string tarih, string starthour, string endhour, string katilimcilar)
        {
            DataSet ds = new DataSet("VL");
            using (SqlConnection conn = new dbConn().conn())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Toplanti_Kayit_proc";

                cmd.Parameters.Add("@konu", SqlDbType.NVarChar, 150).Value = baslik;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = tarih;
                cmd.Parameters.Add("@ssaat", SqlDbType.NChar, 10).Value = starthour;
                cmd.Parameters.Add("@esaat", SqlDbType.NChar, 10).Value = endhour;
                cmd.Parameters.Add("@katilimci", SqlDbType.NVarChar, 550).Value = katilimcilar;

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "V");
                conn.Close();
            }
            return ds;
        }

        public DataSet List()
        {
            DataSet ds = new DataSet("VL");
            using (SqlConnection conn = new dbConn().conn())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Toplanti_Kayit_list";

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "V");
                conn.Close();
            }
            return ds;
        }
        public DataSet Sil(string id)
        {
            DataSet ds = new DataSet("VL");
            using (SqlConnection conn = new dbConn().conn())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Toplanti_Kayit_Sil";

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "V");
                conn.Close();
            }
            return ds;
        }

        public DataSet Guncelle(string id, string baslik, string tarih, string starthour, string endhour, string katilimcilar)
        {
            DataSet ds = new DataSet("VL");
            using (SqlConnection conn = new dbConn().conn())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Toplanti_Kayit_Guncelle";

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                cmd.Parameters.Add("@konu", SqlDbType.NVarChar, 150).Value = baslik;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = tarih;
                cmd.Parameters.Add("@ssaat", SqlDbType.NChar, 10).Value = starthour;
                cmd.Parameters.Add("@esaat", SqlDbType.NChar, 10).Value = endhour;
                cmd.Parameters.Add("@katilimci", SqlDbType.NVarChar, 550).Value = katilimcilar;

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "V");
                conn.Close();
            }
            return ds;
        }
    }
}