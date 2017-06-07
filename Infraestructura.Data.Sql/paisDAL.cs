using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Entidades;
using System.Data.SqlClient;

namespace Infraestructura.Data.Sql
{
    public class paisDAL
    {


        public List<tb_paises> listaPaises()
        {

            List<tb_paises> lista = new List<tb_paises>();
            conexionSQL conecta = new conexionSQL();

            SqlCommand cmd = new SqlCommand("select * from tb_paises", conecta.CN);
            conecta.CN.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tb_paises reg = new tb_paises();

                reg.idpais = dr.GetString(0);
                reg.nombrepais = dr.GetString(1);

                lista.Add(reg);

            }

            conecta.CN.Close();
            dr.Close();

            return lista;

        }



    }

}
