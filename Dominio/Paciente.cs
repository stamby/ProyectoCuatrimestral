using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoCuatrimestral.Dominio
{
    public class Paciente : Persona
    {
        public Paciente()
        {
            _EsMedico = false;
        }
        public string ObraSocial { get; set; }
    }
}