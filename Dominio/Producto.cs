using System;

namespace ProyectoCuatrimestral.Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public Marca MarcaProducto { get; set; }
        public Usuario Oferente { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Unidades { get; set; }
        public decimal PrecioLista { get; set; }
        public Uri Ilustracion { get; set; }
    }
}