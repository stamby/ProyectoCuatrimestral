namespace ProyectoCuatrimestral.Dominio
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Especialidad()
        {

        }

        public Especialidad(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        override public string ToString()
        {
            return Nombre;
        }
    }
}