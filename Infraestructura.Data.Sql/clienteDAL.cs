using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Dominio.Entidades;
using System.Data.Common;

namespace Infraestructura.Data.Sql
{
    public class clienteDAL
    {
        conexionSQL conecta = new conexionSQL();

        //crear una lista 
        public List<tb_clientes> listadoClientes() {

            List<tb_clientes> lista = new List<tb_clientes>();

            SqlCommand cmd = new SqlCommand("select * from tb_clientes",conecta.CN);

            conecta.CN.Open();

             SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {

                tb_clientes reg = new tb_clientes();
                reg.idcliente = dr.GetString(0);
                reg.nombrecia = dr.GetString(1);
                reg.direccion = dr.GetString(2);
                reg.idpais = dr.GetString(3);
                reg.telefono = dr.GetString(4);

                lista.Add(reg); 
            }
            conecta.CN.Close();
            dr.Close();

            return lista;

        }

      
        public string AgregarCliente(tb_clientes reg) {

            string msg = "";
            
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tb_clientes values(@id,@nom,@dir,@idpais,@tel)",conecta.CN);
                conecta.CN.Open();

                cmd.Parameters.AddWithValue("@id",reg.idcliente);
                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@idpais", reg.idpais);
                cmd.Parameters.AddWithValue("@tel", reg.telefono);

                cmd.ExecuteNonQuery();
                msg = "Registro Agregado";
            }
            catch (SqlException e)
            {
                msg = e.Message;
            }
            finally {
                conecta.CN.Close();
            }

            return msg;
        }


        public string ActualizarCliente(tb_clientes reg) {
            string msg = "";


            
            try
            {

                SqlCommand cmd = new SqlCommand("update tb_clientes set nombrecia=@nom,direccion=@dir,idpais=@idpais,telefono=@tel where idcliente=@id",conecta.CN);
                conecta.CN.Open();

                cmd.Parameters.AddWithValue("@nom",reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@idpais", reg.idpais);
                cmd.Parameters.AddWithValue("@tel", reg.telefono);
                cmd.Parameters.AddWithValue("@id", reg.idcliente);

                
                cmd.ExecuteNonQuery();
                msg = "Actualizacion Correcta";
                
            }
            catch (SqlException e) {
               msg= e.Message;
            }
            finally {

                conecta.CN.Close();
            }


            return msg;
        }


        public string EliminarCliente(tb_clientes reg) {
            string msg = "";
            conecta.CN.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("delete from tb_clientes where idcliente=@id",conecta.CN);
                cmd.Parameters.AddWithValue("@id",reg.idcliente);

                cmd.ExecuteNonQuery();
                msg = "Eliminacion Correcta";


            }
            catch (SqlException e)
            {
                msg = e.Message;
            }
            finally {
                conecta.CN.Close();
            }

            return msg;

        }




    }
}
