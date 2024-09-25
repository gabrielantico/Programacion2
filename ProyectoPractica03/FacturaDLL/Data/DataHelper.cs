using FacturaDLL.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaDLL.Data
{
    public class DataHelper
    {
        private static DataHelper helper;
        private string cnnString = @"Data Source=DESKTOP-VSD47N1\DATABASEGABI;Initial Catalog=negocio;Integrated Security=True;Encrypt=False";
        private SqlConnection _cnn;

        private DataHelper()
        {
            _cnn = new SqlConnection(cnnString);
        }

        public static DataHelper GetHelper()
        {
            if(helper == null)
                helper = new DataHelper();
            return helper;
        }

        public SqlConnection GetConnection()
        {
            return _cnn;
        }

        public DataTable EjecutarConsultaSql(List<Parametro>? parametros, string consulta)
        {
            SqlCommand cmd = new SqlCommand(consulta, _cnn);
            cmd.CommandType = CommandType.Text;

            _cnn.Open();
            if(parametros != null && parametros.Count > 0)
            {
                foreach (var p in parametros)
                {
                    cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                }
            }
            
            DataTable dt = new DataTable();

            dt.Load(cmd.ExecuteReader());

            _cnn.Close();

            return dt;
        }
    }
}
