using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Proyecto_Practica01_.Domain;
using System.Security.Cryptography;

namespace Proyecto_Practica01_.Data
{
    public class DataHelper
    {
        private static DataHelper helper;

        private string cnnString = @"Data Source=DESKTOP-VSD47N1\DATABASEGABI;Initial Catalog=negocio;Integrated Security=True;Encrypt=False";
        private SqlConnection cnn;

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

        public int InsertBill(Bill b)
        {
            SqlTransaction t = null;
            SqlCommand cmd;
            int affectedRows;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd = new SqlCommand("SP_Insertar_Maestro", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cliente", b.Client);
                cmd.Parameters.AddWithValue("@forma", b.PayMethod);

                SqlParameter output = new SqlParameter();
                output.ParameterName = "@nro";
                output.SqlDbType = SqlDbType.Int; // Tipo de dato de salida
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                

                affectedRows = cmd.ExecuteNonQuery();

                int result = (int)cmd.Parameters["@nro"].Value;

                int idDetail = 1;
                foreach (BillDetail detail in b.GetList())
                {
                    SqlCommand cmdDetail = new SqlCommand("SP_Insertar_Detalle", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;

                    cmdDetail.Parameters.AddWithValue("@detalle", idDetail);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Count);
                    cmdDetail.Parameters.AddWithValue("@articulo", detail.Article);
                    cmdDetail.Parameters.AddWithValue("@nro", result);

                    cmdDetail.ExecuteNonQuery();

                    idDetail++;
                }

                t.Commit();
            }
            catch (SqlException ex)
            {
                t.Rollback();
                affectedRows = 0;
            }
            finally
            {
                cnn.Close();
            }
            
            return affectedRows;
        }
    }
}
