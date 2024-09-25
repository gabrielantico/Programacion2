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
    public class RepositoryFactura : IAplicacion
    {
        public bool Actualizar(int id, Factura factura)
        {
            SqlConnection _cnn = DataHelper.GetHelper().GetConnection();
            SqlTransaction t = null;
            int filasAfectadas;
            try
            {
                _cnn.Open();
                t = _cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_Actualizar_Maestro", _cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                
                
                cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@cliente", factura.Cliente);
                cmd.Parameters.AddWithValue("@forma", factura.Forma.IdForma);
                cmd.Parameters.AddWithValue("@nroFactura", id);

                filasAfectadas = cmd.ExecuteNonQuery();

                if(factura.Detalles != null && factura.Detalles.Count > 0)
                {
                    foreach (var d in factura.Detalles)
                    {
                        SqlCommand cmdDetail = new SqlCommand("SP_Actualizar_Detalle", _cnn, t);
                        cmdDetail.CommandType = CommandType.StoredProcedure;

                        cmdDetail.Parameters.AddWithValue("@nroDetalle", d.NroDetalle);
                        cmdDetail.Parameters.AddWithValue("@cantidad", d.Cantidad);
                        cmdDetail.Parameters.AddWithValue("@articulo", d.Articulo.IdArticulo);

                        cmdDetail.ExecuteNonQuery();
                    }
                }
                t.Commit();
                _cnn.Close();
                
            }
            catch (Exception ex)
            {
                filasAfectadas = 0;
                t.Rollback();
            }
            finally
            {
                if(_cnn.State == ConnectionState.Open)
                {
                    _cnn.Close();
                }
            }
            return filasAfectadas == 1;
        }

        public List<Factura> Consultar(DateTime? fecha, int? idFormaPago)
        {
            List<Parametro> parametros = new List<Parametro>();
            if (fecha != null && idFormaPago == null)
            {
                parametros.Add(new Parametro("@fecha", fecha));
            }
            else if (idFormaPago != null && fecha == null)
            {
                parametros.Add(new Parametro("@forma", idFormaPago));
            }
            else if (fecha != null && idFormaPago != null)
            {
                parametros.Add(new Parametro("@fecha", fecha));
                parametros.Add(new Parametro("@forma", idFormaPago));
            }
            else
            {
                parametros = null;
            }
            bool primerParametro = false;
            string consulta = "select * from facturas";
            if (parametros != null)
            {
                consulta += " where";
                foreach (var p in parametros)
                {
                    
                    if (p.Nombre == "@fecha")
                    {
                        consulta += " fecha = @fecha";
                        primerParametro = true;
                    }
                    else if (p.Nombre == "@forma" && primerParametro == false)
                    {
                        consulta += " id_forma_pago = @forma";
                    }
                    else
                    {
                        consulta += " and id_forma_pago = @forma";
                    }
                }

            }

            DataTable dt = DataHelper.GetHelper().EjecutarConsultaSql(parametros, consulta);

            List<Factura> facturas = new List<Factura>();
            foreach (DataRow row in dt.Rows)
            {
                Factura factura = new Factura();

                factura.NroFactura = Convert.ToInt32(row[0]);
                factura.Fecha = Convert.ToDateTime(row[1]);
                factura.Cliente = Convert.ToString(row[2]);
                factura.Forma.IdForma = Convert.ToInt32(row[3]);
                facturas.Add(factura);
            }
            return facturas;
        }

        public bool Registrar(Factura factura)
        {
            SqlConnection _cnn = DataHelper.GetHelper().GetConnection();
            SqlTransaction t = null;
            int filasAfectadas;
            try
            {
                _cnn.Open();
                t = _cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_Insertar_Maestro", _cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                
                
                cmd.Parameters.AddWithValue("@cliente", factura.Cliente);
                cmd.Parameters.AddWithValue("@forma", factura.Forma.IdForma);

                SqlParameter output = new SqlParameter();
                output.ParameterName = "@nro";
                output.SqlDbType = SqlDbType.Int; // Tipo de dato de salida
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                filasAfectadas = cmd.ExecuteNonQuery();

                int nroFactura = (int)cmd.Parameters["@nro"].Value;

                int nroDetalle = 1;
                foreach (var d in factura.Detalles)
                {
                    SqlCommand cmdDetail = new SqlCommand("SP_Insertar_Detalle", _cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;

                    cmdDetail.Parameters.AddWithValue("@detalle", nroDetalle);
                    cmdDetail.Parameters.AddWithValue("@cantidad", d.Cantidad);
                    cmdDetail.Parameters.AddWithValue("@articulo", d.Articulo.IdArticulo);
                    cmdDetail.Parameters.AddWithValue("@nro", nroFactura);

                    cmdDetail.ExecuteNonQuery();

                    nroDetalle++;
                }
                t.Commit();
                _cnn.Close();
                
            }
            catch (Exception ex)
            {
                t.Rollback();
                filasAfectadas = 0;
            }
            finally
            {
                if(_cnn.State == ConnectionState.Open)
                {
                    _cnn.Close();
                }
            }

            return filasAfectadas == 1;
        }
    }
}
