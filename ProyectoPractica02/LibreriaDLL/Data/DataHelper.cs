using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LibreriaDLL.Data
{
    public class DataHelper
    {
        private static DataHelper helper;
        private SqlConnection cnn;
        private string cnnString = @"Data Source=DESKTOP-VSD47N1\DATABASEGABI;Initial Catalog=negocio;Integrated Security=True;Encrypt=False";

        private DataHelper()
        {
            cnn = new SqlConnection(cnnString);
        }

        public static DataHelper GetHelper()
        {
            if (helper == null)
            {
                helper = new DataHelper();
            }
            return helper;
        }

        public DataTable ExecuteSqlQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();

                
                dt.Load(cmd.ExecuteReader());

                cnn.Close();
            }
            catch (SqlException ex)
            {
                if(cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return dt;
        }

        public int ExecuteSqlNonQuery(string sp, List<Parametro> lst)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();

                foreach (Parametro p in lst)
                {
                    cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                }

                int filasAfectadas = cmd.ExecuteNonQuery();

                cnn.Close();

                return filasAfectadas;
            }
            catch (SqlException ex)
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Close();
                }

                return 0;
            }
        }
    }
}
