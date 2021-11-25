using System;
using System.Collections.Generic;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral.Negocio
{
    public class MarcaNegocio
    {
        public Marca Nuevo(string nombre)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@nombre", nombre);
            acceso.SetConsulta(
                "insert into MARCAS (nombre) values (@nombre);");
            Marca marca = new Marca();
            marca.Id = acceso.EjecutarEscalar();
            marca.Nombre = nombre;
            acceso.CerrarConexion();

            return marca;
        }
        public void Modificar(Marca marca)
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@ID", marca.Id);
            acceso.SetParametros("@nombre", marca.Nombre);

            acceso.SetConsulta(
                "update MARCAS set nombre = @nombre where id = @ID;");

            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public void Borrar(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", ID);
            acceso.SetConsulta(
                "delete from MARCAS where ID = @ID;");
            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public Marca DesdeID(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetConsulta(
                "select nombre from MARCAS where id = " +
                ID + ";");
            acceso.EjecutarLectura();
            Marca marca = new Marca();
            marca.Id = ID;

            bool correcto = acceso.Lector.Read();

            if (correcto)
            {
                marca.Nombre = (string)acceso.Lector["nombre"];
                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }

            return marca;
        }
        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetConsulta("select id, nombre from MARCAS");
            acceso.EjecutarLectura();
            
            while (acceso.Lector.Read())
            {
                lista.Add(
                    new Marca(
                        Convert.ToInt32(acceso.Lector["id"]),
                        (string)acceso.Lector["nombre"]));
            }

            acceso.CerrarConexion();
            
            return lista;
        }
    }
}