using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Infraestructura.Data.Sql
{
    public class conexionSQL
    {
        SqlConnection cn = new SqlConnection("server=.;database=Negocios2017;uid=sa;pwd=sql");


        public SqlConnection CN{
            get{ return cn; }
        }



    }
}
