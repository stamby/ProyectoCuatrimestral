using System;
using System.Collections.Generic;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral.Negocio
{
    public class MedicoNegocio
    {
        public Medico Nuevo(
            string Nombre,
            string Apellido,
            string Email,
            string Clave,
            int especialidadId)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@Nombre", Nombre);
            acceso.SetParametros("@Apellido", Apellido);
            acceso.SetParametros("@Email", Email);
            acceso.SetParametros("@Clave", Clave);
            acceso.SetParametros("@Especialidad", especialidadId);
            acceso.SetConsulta(
                "insert into MEDICOS (nombre, apellido, email, clave, especialidad_id) values ("
                + "@Nombre, @Apellido, @Email, @Clave, @Especialidad);");

            int Id = acceso.EjecutarEscalar();

            acceso.CerrarConexion();

            if (Id != 0)
                return DesdeID(Id);

            return null;
        }
        public void Modificar(Medico medico)
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@ID", medico.Id);
            acceso.SetParametros("@Nombre", medico.Nombre);
            acceso.SetParametros("@Apellido", medico.Apellido);
            acceso.SetParametros("@Email", medico.Email);
            acceso.SetParametros("@Clave", medico.Clave);
            acceso.SetParametros("@Especialidad", medico.Especialidad.Id);

            acceso.SetConsulta(
                "update MEDICOS set nombre = @Nombre, apellido = @Apellido, "
                + "email = @Email, clave = @Clave, especialidad_id = @Especialidad "
                + "where id = @ID;");

            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public void Borrar(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", ID);
            acceso.SetConsulta(
                "delete from MEDICOS where ID = @ID;");
            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public Medico DesdeID(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetConsulta(
                "select m.nombre medico_nombre, m.apellido medico_apellido, m.email medico_email, " +
                "clave medico_clave, especialidad_id especialidad_id, e.nombre especialidad_nombre from MEDICOS m " +
                "left join ESPECIALIDADES e on m.especialidad_id = e.id " +
                "where m.id = " +
                ID + ";");

            acceso.EjecutarLectura();

            Medico medico = new Medico();

            medico.Id = ID;

            bool correcto = acceso.Lector.Read();

            if (correcto)
            {
                medico.Nombre = (string)acceso.Lector["medico_nombre"];
                medico.Apellido = (string)acceso.Lector["medico_apellido"];
                medico.Email = (string)acceso.Lector["medico_email"];
                medico.Clave = (string)acceso.Lector["medico_clave"];
                medico.Especialidad = new Especialidad();
                medico.Especialidad.Id = Convert.ToInt32(acceso.Lector["especialidad_id"]);
                medico.Especialidad.Nombre = (string)acceso.Lector["especialidad_nombre"];

                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }

            return medico;
        }
        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos acceso = new AccesoDatos();
            
            acceso.SetConsulta(
                "select m.id, m.nombre, m.apellido, m.email, m.clave, m.especialidad_id, "
                + "e.nombre AS especialidad_nombre "
                + "from MEDICOS m left join ESPECIALIDADES e on m.especialidad_id = e.id;");

            acceso.EjecutarLectura();

            Medico medico;

            while (acceso.Lector.Read())
            {
                medico = new Medico();
                medico.Id = Convert.ToInt32(acceso.Lector["id"]);
                medico.Nombre = (string)acceso.Lector["nombre"];
                medico.Apellido = (string)acceso.Lector["apellido"];
                medico.Email = (string)acceso.Lector["email"];
                medico.Clave = (string)acceso.Lector["clave"];
                medico.Especialidad = new Especialidad
                {
                    Id = Convert.ToInt32(acceso.Lector["especialidad_id"]),
                    Nombre = (string)acceso.Lector["especialidad_nombre"]
                };


                lista.Add(medico);
            }
            acceso.CerrarConexion();

            return lista;
        }
        public Medico Ingresar(string strEmail, string strClave)
        {
            Medico medico = new Medico();
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@Email", strEmail);
            acceso.SetParametros("@Clave", strClave);

            acceso.SetConsulta(
                "select m.id MedicoID, m.nombre MedicoNombre, m.apellido apellido, m.email email, "
                + "m.clave clave, m.especialidad_id EspecialidadID, e.nombre EspecialidadNombre "
                + "from MEDICOS m "
                + "left join ESPECIALIDADES e on m.especialidad_id = e.id "
                + "where email = @Email and clave = @Clave;");

            acceso.EjecutarLectura();

            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

            if (acceso.Lector.Read())
            {
                medico.Id = Convert.ToInt32(acceso.Lector["MedicoID"]);
                medico.Nombre = (string)acceso.Lector["MedicoNombre"];
                medico.Apellido = (string)acceso.Lector["apellido"];
                medico.Email = (string)acceso.Lector["email"];
                medico.Clave = (string)acceso.Lector["clave"];
                medico.Especialidad = new Especialidad();
                medico.Especialidad.Id = Convert.ToInt32(acceso.Lector["EspecialidadID"]);
                medico.Especialidad.Nombre = (string)acceso.Lector["EspecialidadNombre"];

                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }
            
            return medico;
        }
    }
}