namespace ProyectoCuatrimestral.Dominio
{
    public class Medico : Persona
    {
        public Medico()
        {
            _EsMedico = true;
        }
        public Especialidad Especialidad { get; set; }
        public bool EsAdministrador()
        {
            return Especialidad.Id == 1;
        }
        override public string ToString()
        {
            return Apellido + ", " + Nombre;
        }
    }
}