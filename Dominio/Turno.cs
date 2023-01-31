using System;

namespace ProyectoCuatrimestral.Dominio
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime HoraDesde { get; set; }
        public DateTime HoraHasta { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}