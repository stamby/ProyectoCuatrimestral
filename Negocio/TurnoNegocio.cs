using System;
using System.Collections.Generic;

using ProyectoCuatrimestral.Dominio;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public enum TipoDia
{
    Vacio = 0,
    Disponible = 1,
    Reservado = 2
}

namespace ProyectoCuatrimestral.Negocio
{
    public class TurnoNegocio
    {
        public Turno Nuevo(
            DateTime HoraDesde,
            DateTime HoraHasta,
            Medico MedicoAsociado)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@HoraDesde", HoraDesde);
            acceso.SetParametros("@HoraHasta", HoraHasta);
            acceso.SetParametros("@IdMedico", MedicoAsociado.Id);

            acceso.SetConsulta(
                "insert into TURNOS (hora_desde, hora_hasta, medico_id) values ("
                + "@HoraDesde, @HoraHasta, @IdMedico);");

            int Id = acceso.EjecutarEscalar();

            acceso.CerrarConexion();

            if (Id != 0)
                return DesdeID(Id);

            return null;
        }
        public void Modificar(Turno turno)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", turno.Id);
            acceso.SetParametros("@HoraDesde", turno.HoraDesde);
            acceso.SetParametros("@HoraHasta", turno.HoraHasta);
            acceso.SetParametros("@IdMedico", turno.Medico.Id);

            acceso.SetConsulta(
                "update TURNOS set hora_desde = @HoraDesde, hora_hasta = @HoraHasta, "
                + "medico_id = @IdMedico where id = @ID;");

            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public void Borrar(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", ID);
            acceso.SetConsulta(
                "delete from TURNOS where ID = @ID;");
            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public void Borrar(Turno turno)
        {
            Borrar(turno.Id);
        }
        public Turno DesdeID(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetConsulta(
                "select t.hora_desde HoraDesde, t.hora_hasta HoraHasta, t.medico_id IdMedico, "
                + "m.nombre NombreMedico, m.apellido ApellidoMedico, m.email EmailMedico, "
                + "m.especialidad_id IdEspecialidad, e.nombre NombreEspecialidad, "
                + "t.paciente_id IdPaciente, r.nombre NombrePaciente, r.apellido ApellidoPaciente, "
                + "r.email EmailPaciente, r.obra_social ObraSocialPaciente "
                + "from TURNOS t "
                + "left join PACIENTES r on t.paciente_id = r.id "
                + "left join MEDICOS m on t.medico_id = m.id "
                + "left join ESPECIALIDADES e on m.especialidad_id = e.id "
                + "where t.id = " + ID + ";");

            acceso.EjecutarLectura();

            Turno turno = new Turno();
            
            bool correcto = acceso.Lector.Read();

            if (!correcto)
            {
                acceso.CerrarConexion();
                return null;
            }

            turno.Id = ID;
            turno.HoraDesde = (DateTime)acceso.Lector["HoraDesde"];
            turno.HoraHasta = (DateTime)acceso.Lector["HoraHasta"];
            if (!(acceso.Lector["IdMedico"] is DBNull))
            {
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                turno.Medico = medicoNegocio.DesdeID(Convert.ToInt32(acceso.Lector["IdMedico"]));
                /*
                turno.Medico = new Medico();
                turno.Medico.Id = Convert.ToInt32(acceso.Lector["IdMedico"]);
                turno.Medico.Nombre = (string)acceso.Lector["NombreMedico"];
                turno.Medico.Apellido = (string)acceso.Lector["ApellidoMedico"];
                turno.Medico.Email = (string)acceso.Lector["EmailMedico"];
                
                if (acceso.Lector["IdEspecialidad"] != null)
                {
                    turno.Medico.Especialidad = new Especialidad();
                    turno.Medico.Especialidad.Id = Convert.ToInt32(acceso.Lector["IdEspecialidad"]);
                    turno.Medico.Especialidad.Nombre = (string)acceso.Lector["NombreEspecialidad"];
                }
                */
            }
            else
            {
                turno.Medico = null;
            }
            if (!(acceso.Lector["IdPaciente"] is DBNull))
            {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();

                turno.Paciente = pacienteNegocio.DesdeID(Convert.ToInt32(acceso.Lector["IdPaciente"]));

                /*
                turno.Paciente = new Paciente();
                turno.Paciente.Id = Convert.ToInt32(acceso.Lector["IdPaciente"]);
                turno.Paciente.Nombre = (string)acceso.Lector["NombrePaciente"];
                turno.Paciente.Apellido = (string)acceso.Lector["ApellidoPaciente"];
                turno.Paciente.Email = (string)acceso.Lector["EmailPaciente"];
                turno.Paciente.ObraSocial = (string)acceso.Lector["ObraSocialPaciente"];
                */
            }
            else
            {
                turno.Paciente = null;
            }

            acceso.CerrarConexion();

            return turno;
        }
        /*
         * 
         * Al pasar por parámetro una especialidad, filtra los turnos relacionados a ella.
         * Cuando el paciente no es nulo, busca los turnos de un paciente en particular.
         * 
         */
                public List<Turno> Listar(
                DateTime hora_desde,
                DateTime hora_hasta,
                Especialidad especialidad=null,
                Medico medico=null,
                Paciente paciente=null)
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos acceso = new AccesoDatos();
            Turno turno;

            acceso.SetParametros("@HoraDesde", hora_desde);
            acceso.SetParametros("@HoraHasta", hora_hasta);

            acceso.SetConsulta(
                "select t.id IdTurno, t.hora_desde HoraDesde, t.hora_hasta HoraHasta, t.medico_id IdMedico, "
                + "m.nombre NombreMedico, m.apellido ApellidoMedico, m.email EmailMedico, "
                + "m.especialidad_id IdEspecialidad, e.nombre NombreEspecialidad, "
                + "t.paciente_id IdPaciente, p.nombre NombrePaciente, p.apellido ApellidoPaciente, "
                + "p.email EmailPaciente, p.obra_social ObraSocialPaciente "
                + "from TURNOS t "
                + "left join PACIENTES p on t.paciente_id = p.id "
                + "left join MEDICOS m on t.medico_id = m.id "
                + "left join ESPECIALIDADES e on m.especialidad_id = e.id "
                + "where t.hora_desde >= @HoraDesde and t.hora_desde <= @HoraHasta "
                + (medico == null ? "" : " and m.id = " + medico.Id)
                + (especialidad == null ? "" : " and m.especialidad_id = " + especialidad.Id)
                + (paciente == null ? "" : " and t.paciente_id = " + paciente.Id)
                + " order by t.hora_desde, m.apellido, m.nombre"
                + (paciente == null ? ", p.apellido, p.nombre" : "")
                + ";");

            acceso.EjecutarLectura();

            while (acceso.Lector.Read())
            {
                turno = new Turno();
                turno.Id = Convert.ToInt32(acceso.Lector["IdTurno"]);
                turno.HoraDesde = (DateTime)acceso.Lector["HoraDesde"];
                turno.HoraHasta = (DateTime)acceso.Lector["HoraHasta"];
                if (!(acceso.Lector["IdMedico"] is DBNull))
                {
                    turno.Medico = new Medico();
                    turno.Medico.Id = Convert.ToInt32(acceso.Lector["IdMedico"]);
                    turno.Medico.Nombre = (string)acceso.Lector["NombreMedico"];
                    turno.Medico.Apellido = (string)acceso.Lector["ApellidoMedico"];
                    turno.Medico.Email = (string)acceso.Lector["EmailMedico"];
                    if (!(acceso.Lector["IdEspecialidad"] is DBNull))
                    {
                        turno.Medico.Especialidad = new Especialidad();

                        turno.Medico.Especialidad.Id = Convert.ToInt32(acceso.Lector["IdEspecialidad"]);
                        turno.Medico.Especialidad.Nombre = (string)acceso.Lector["NombreEspecialidad"];
                    }
                }
                else
                {
                    turno.Medico = null;
                }
                if (!(acceso.Lector["IdPaciente"] is DBNull))
                {
                    turno.Paciente = new Paciente();
                    turno.Paciente.Id = Convert.ToInt32(acceso.Lector["IdPaciente"]);
                    turno.Paciente.Nombre = (string)acceso.Lector["NombrePaciente"];
                    turno.Paciente.Apellido = (string)acceso.Lector["ApellidoPaciente"];
                    turno.Paciente.Email = (string)acceso.Lector["EmailPaciente"];
                    turno.Paciente.ObraSocial = (string)acceso.Lector["ObraSocialPaciente"];
                }
                else
                {
                    turno.Paciente = null;
                }

                lista.Add(turno);
            }
            
            acceso.CerrarConexion();
            
            return lista;
        }
        public int[] ContarPorDia(
                int anio,
                int mes,
                Medico medico = null)
        {
            int[] turnos = new int[32];

            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@HoraDesde", DateTime.ParseExact(
                anio.ToString() + mes.ToString(), "yyyyMM", null));
            acceso.SetParametros("@HoraHasta", DateTime.ParseExact(
                anio.ToString() + (mes + 1).ToString(), "yyyyMM", null));

            acceso.SetConsulta(
                "select convert(date, hora_desde) as Fecha, count(hora_desde) as Cantidad "
                + "from TURNOS where hora_desde >= @HoraDesde and hora_desde < @HoraHasta "
                + (medico == null ? "" : " and medico_id = " + medico.Id)
                + " group by convert(date, hora_desde)");

            acceso.EjecutarLectura();

            int dia_actual;

            while (acceso.Lector.Read())
            {
                dia_actual = ((DateTime)acceso.Lector["Fecha"]).Day;
                turnos[dia_actual] = (int)acceso.Lector["Cantidad"];
            }
            
            return turnos;
        }
    }
}