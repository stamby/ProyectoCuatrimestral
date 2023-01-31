using System;
using System.Collections.Generic;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral.Negocio
{
    public class EspecialidadNegocio
    {
        public Especialidad Nuevo(string nombre)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@nombre", nombre);
            acceso.SetConsulta(
                "insert into ESPECIALIDADES (nombre) values (@nombre);");
            Especialidad especialidad = new Especialidad();
            especialidad.Id = acceso.EjecutarEscalar();
            especialidad.Nombre = nombre;
            acceso.CerrarConexion();

            return especialidad;
        }
        public void Modificar(Especialidad especialidad)
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@ID", especialidad.Id);
            acceso.SetParametros("@Nombre", especialidad.Nombre);

            acceso.SetConsulta(
                "update ESPECIALIDADES set nombre = @Nombre where id = @ID;");

            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public void Borrar(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", ID);
            acceso.SetConsulta(
                "delete from ESPECIALIDADES where ID = @ID;");
            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public Especialidad DesdeID(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetConsulta(
                "select nombre from ESPECIALIDADES where id = " +
                ID + ";");
            acceso.EjecutarLectura();
            Especialidad especialidad = new Especialidad();
            especialidad.Id = ID;

            bool correcto = acceso.Lector.Read();

            if (correcto)
            {
                especialidad.Nombre = (string)acceso.Lector["nombre"];
                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }

            return especialidad;
        }
        public List<Especialidad> Listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetConsulta("select id, nombre from ESPECIALIDADES");
            acceso.EjecutarLectura();
            
            while (acceso.Lector.Read())
            {
                lista.Add(
                    new Especialidad(
                        Convert.ToInt32(acceso.Lector["id"]),
                        (string)acceso.Lector["nombre"]));
            }

            acceso.CerrarConexion();
            
            return lista;
        }
    }
}