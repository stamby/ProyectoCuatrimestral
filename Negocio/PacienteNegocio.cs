using System;
using System.Collections.Generic;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral.Negocio
{
    public class PacienteNegocio
    {
        public Paciente Nuevo(
            string Nombre,
            string Apellido,
            string Email,
            string ObraSocial)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@Nombre", Nombre);
            acceso.SetParametros("@Apellido", Apellido);
            acceso.SetParametros("@Email", Email);
            acceso.SetParametros("@ObraSocial", ObraSocial);
            acceso.SetConsulta(
                "insert into PACIENTES (nombre, apellido, email, obra_social) values ("
                + "@Nombre, @Apellido, @Email, @ObraSocial);");

            int Id = acceso.EjecutarEscalar();

            acceso.CerrarConexion();

            if (Id != 0)
                return DesdeID(Id);

            return null;
        }
        public void Modificar(Paciente paciente)
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@ID", paciente.Id);
            acceso.SetParametros("@Nombre", paciente.Nombre);
            acceso.SetParametros("@Apellido", paciente.Apellido);
            acceso.SetParametros("@Email", paciente.Email);
            acceso.SetParametros("@ObraSocial", paciente.ObraSocial);

            acceso.SetConsulta(
                "update PACIENTES set nombre = @Nombre, apellido = @Apellido, "
                + "email = @Email, obra_social = @ObraSocial "
                + "where id = @ID;");

            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public void Borrar(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", ID);
            acceso.SetConsulta(
                "delete from PACIENTES where ID = @ID;");
            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public Paciente DesdeID(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetConsulta(
                "select nombre, apellido, email, obra_social from PACIENTES where id = " +
                ID + ";");

            acceso.EjecutarLectura();

            Paciente paciente = new Paciente();

            paciente.Id = ID;

            bool correcto = acceso.Lector.Read();

            if (correcto)
            {
                paciente.Nombre = (string)acceso.Lector["nombre"];
                paciente.Apellido = (string)acceso.Lector["apellido"];
                paciente.Email = (string)acceso.Lector["email"];
                paciente.Clave = (string)acceso.Lector["clave"];
                paciente.ObraSocial = (string)acceso.Lector["obra_social"];

                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }

            return paciente;
        }
        public List<Paciente> Listar()
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos acceso = new AccesoDatos();
            
            acceso.SetConsulta(
                "select id, nombre, apellido, email, obra_social from PACIENTES");
            acceso.EjecutarLectura();

            Paciente paciente;

            while (acceso.Lector.Read())
            {
                paciente = new Paciente();
                paciente.Id = Convert.ToInt32(acceso.Lector["id"]);
                paciente.Nombre = (string)acceso.Lector["nombre"];
                paciente.Apellido = (string)acceso.Lector["apellido"];
                paciente.Email = (string)acceso.Lector["email"];
                paciente.ObraSocial = (string)acceso.Lector["obra_social"];

                lista.Add(paciente);
            }
            acceso.CerrarConexion();

            return lista;
        }
        public Paciente Ingresar(string strEmail, string strClave)
        {
            Paciente paciente = new Paciente();

            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@Email", strEmail);
            acceso.SetParametros("@Clave", strClave);

            acceso.SetConsulta(
                "select id, nombre, apellido, email, clave, obra_social "
                + "from PACIENTES u "
                + "where email = @Email and clave = @Clave;");

            acceso.EjecutarLectura();

            if (acceso.Lector.Read())
            {
                paciente.Id = Convert.ToInt32(acceso.Lector["id"]);
                paciente.Nombre = (string)acceso.Lector["nombre"];
                paciente.Apellido = (string)acceso.Lector["apellido"];
                paciente.Email = (string)acceso.Lector["email"];
                paciente.Clave = (string)acceso.Lector["clave"];
                paciente.ObraSocial = (string)acceso.Lector["obra_social"];

                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }
            
            return paciente;
        }
    }
}