namespace ProyectoCuatrimestral.Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        // True = medico, false = paciente
        protected bool _EsMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        override public string ToString()
        {
            return Apellido + ", " + Nombre;
        }
        public bool EsMedico()
        {
            return _EsMedico;
        }
    }
}