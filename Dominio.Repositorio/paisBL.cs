using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//importar
using Dominio.Entidades;
using Infraestructura.Data.Sql;
namespace Dominio.Repositorio
{
    public class paisBL
    {
        public List<tb_paises> listaPaises() {

            paisDAL pais = new paisDAL();

            return pais.listaPaises();


        }


    }
}
