using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyApp01
{
    internal class Datos
    {

        string cadenaConexion = "Server=localhost;Database=Agenda;User=sa;Password=l12345678.;Encrypt=False;";

        public Datos()
        {

        }
        private SqlConnection conexionOpen()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return null;
            }
        }
        private void conexionClose(SqlConnection conexion)
        {
            try { conexion.Close(); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        public bool ejecutar(string command)
        {
            try
            {
                SqlConnection conectar = conexionOpen();
                SqlCommand sqlCommand = new SqlCommand(command, conectar);
                sqlCommand.ExecuteNonQuery();
                conexionClose(conectar);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return false;
            }
        }

        public bool ejecutar(SqlCommand command)
        {
            try
            {
                SqlConnection conectar = conexionOpen();
                command.Connection = conectar;
                command.ExecuteNonQuery();
                conexionClose(conectar);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return false;
            }
        }

        public DataSet Informacion(string comando)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conecta = conexionOpen();
                SqlDataAdapter da = new SqlDataAdapter(comando, conecta);
                da.Fill(ds);
                conexionClose(conecta);
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return null;
            }
        }
    }
}