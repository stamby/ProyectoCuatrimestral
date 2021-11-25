namespace ProyectoCuatrimestral.Dominio
{
    public enum TipoMovimiento
    {
        COMPRA = 0,
        VENTA = 1
    }
    public class Movimiento
    {
        public int Id { get; set; }
        // El tipo 0 es para la compra; el 1, para la venta.
        public TipoMovimiento Tipo { get; set; }
        public Producto Producto { get; set; }
        public Usuario Comprador { get; set; }
        public decimal Monto { get; set; }
        public int Unidades { get; set; }
    }
}