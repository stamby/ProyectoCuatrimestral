using System;
using System.Data.SqlClient;

namespace ProyectoCuatrimestral.Negocio
{
    public class AccesoDatos
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        public SqlDataReader Lector;

        public AccesoDatos()
        {
            Conexion = new SqlConnection(
                "server = .\\SQLEXPRESS; database = tp; integrated security = true");
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public void SetConsulta(string consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta;
        }

        public void EjecutarLectura()
        {
            Conexion.Open();
            Lector = Comando.ExecuteReader();
        }

        public string GetConsulta()
        {
            string query = Comando.CommandText;

            foreach (SqlParameter p in Comando.Parameters)
            {
                query = query.Replace(p.ParameterName, p.Value.ToString());
            }

            return query;
        }

        public void CerrarConexion()
        {
            if (Lector != null)
            {
                Lector.Close();
                Conexion.Close();
            }
        }

        public bool EjecutarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int EjecutarEscalar()
        {
            Comando.Connection = Conexion;

            int resultado;

            try
            {
                Conexion.Open();
                resultado = Convert.ToInt32(Comando.ExecuteScalar());
            }
            catch
            {
                return 0;
            }

            return resultado;
        }

        public void SetParametros(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}