using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;


namespace WebApi1.Datos
{
    public class CDatos
    {

         
            private MySqlConnection conn;
            private DataSet datos = new DataSet();
            private MySqlDataAdapter adaptador;


            public CDatos()
            {

            }

            private void IniciliazarConection()
            {
                /* datos referentes a nuestro servidor y base de datos*/
                if (conn == null)
                {
                conn = new MySqlConnection()
                {
                    ConnectionString = "Server=localhost;Port=3306;Database=test;Uid=root;"
                };
            }
            }

            public Boolean OpenConection()
            {

                IniciliazarConection();
                //si la connexión está cerrada; se pueden hacer más cosas
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    return true;

                }
                return false;

            }

            public void CloseConection()
            {

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }



            }



            public MySqlConnection Conn
            {
                get { return conn; }


            }

            public void Query(String sql, String nombreConsulta)
            {
                try
                {
                    datos.Tables[nombreConsulta].Clear();
                }
                catch (Exception)
                {


                }
                IniciliazarConection();
                adaptador = new MySqlDataAdapter(sql, conn);
                adaptador.Fill(datos, nombreConsulta);



            }

            public DataTable GetDatos(String nombreConsulta)
            {

                return datos.Tables[nombreConsulta];

            }

            public int EjecutaComando(string sql)
            {

                MySqlCommand comando = new MySqlCommand();
                int i = -1;
                try
                {
                    if (OpenConection())
                    {
                        comando.Connection = conn;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = sql;
                        i = comando.ExecuteNonQuery();
                    }
                    CloseConection();




                }
                catch (Exception e)
                {

                    throw new ApplicationException(e.Message + " Error ejecutano comando");
                }
                return i;
            }

    }
}