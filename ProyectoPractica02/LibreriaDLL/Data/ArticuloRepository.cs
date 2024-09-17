using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaDLL.Domain;


namespace LibreriaDLL.Data
{
    public class ArticuloRepository : IAplicacion
    {
        public List<Articulo> GetAll()
        {
            string query = "select * from articulos";
            List<Articulo> lst = new List<Articulo>();
            DataTable dt = DataHelper.GetHelper().ExecuteSqlQuery(query);

            foreach (DataRow fila in dt.Rows)
            {
                Articulo a = new Articulo();
                a.Codigo = (int)fila[0];
                a.Nombre = (string)fila[1];
                a.PreUnitario = Convert.ToDecimal(fila[2]);

                lst.Add(a);
            }
            return lst;
        }

        public Articulo GetById(int id)
        {
            string query = $"select * from articulos where id_articulo = {id}";
            DataTable dt = DataHelper.GetHelper().ExecuteSqlQuery(query);

            Articulo a = new Articulo();

            foreach (DataRow row in dt.Rows)
            {
                a.Codigo = Convert.ToInt32(row[0]);
                a.Nombre = (string)row[1];
                a.PreUnitario = Convert.ToDecimal(row[2]);
            }

            return a;

        }

        public bool Insert(Articulo a)
        {
            string sp = "SP_Insertar_Articulo";

            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro {Nombre = "@id", Valor = a.Codigo},
                new Parametro {Nombre = "@nombre", Valor = a.Nombre},
                new Parametro {Nombre = "@precio", Valor = a.PreUnitario}
            };

            int filasAfectadas = DataHelper.GetHelper().ExecuteSqlNonQuery(sp, parametros);

            return filasAfectadas == 1;
        }

        public bool Update(Articulo a, int id)
        {
            string sp = "SP_Actualizar_Articulo";

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro(){Nombre = "@id", Valor = id},
                new Parametro(){Nombre = "@nombre", Valor = a.Nombre},
                new Parametro(){Nombre = "@precio", Valor = a.PreUnitario}
            };

            int filasAfectadas = DataHelper.GetHelper().ExecuteSqlNonQuery(sp, parametros);

            return filasAfectadas == 1;
        }

        public bool Delete(int id)
        {
            string sp = "SP_Eliminar_Articulo";

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro() { Nombre = "@id", Valor = id }
            };

            int filasAfectadas = DataHelper.GetHelper().ExecuteSqlNonQuery(sp, parametros);

            return filasAfectadas == 1;
        }
    }
}
