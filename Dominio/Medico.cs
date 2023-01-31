namespace ProyectoCuatrimestral.Dominio
{
    public class Medico : Persona
    {
        public Medico()
        {
            _EsMedico = true;
        }
        public Especialidad Especialidad { get; set; }
        override public string ToString()
        {
            return Apellido + ", " + Nombre;
        }
    }
}