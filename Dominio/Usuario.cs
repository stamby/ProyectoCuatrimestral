namespace ProyectoCuatrimestral.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        // Los permisos del usuario.
        public bool PermisoAdmin { get; set; }
        public bool PermisoComprar { get; set; }
        public bool PermisoVender { get; set; }

        public Usuario() { }

        public Usuario(
            int Id,
            string Nombre,
            bool PermisoAdmin,
            bool PermisoComprar,
            bool PermisoVender)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.PermisoAdmin = PermisoAdmin;
            this.PermisoComprar = PermisoComprar;
            this.PermisoVender = PermisoVender;
        }
    }
}