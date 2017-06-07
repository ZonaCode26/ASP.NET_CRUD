using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Entidades;
using Infraestructura.Data.Sql;

namespace Dominio.Repositorio
{
    public class clienteBL
    {
        public List<tb_clientes> listaClientes() {

            clienteDAL cliente = new clienteDAL();
            return cliente.listadoClientes();


        }
        public string AgregarCliente(tb_clientes reg) {

            clienteDAL cliente = new clienteDAL();
            return cliente.AgregarCliente(reg);
        }


        public string ActualizarCliente(tb_clientes reg) {
            clienteDAL cliente = new clienteDAL();
            return cliente.ActualizarCliente(reg);
        }

        public string EliminarCliente(tb_clientes reg) {

            clienteDAL cliente = new clienteDAL();
            return cliente.EliminarCliente(reg);
        }

    }
}
