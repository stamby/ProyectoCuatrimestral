using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral.Negocio
{

    public class MovimientoNegocio
    {
        public Movimiento Nuevo(
            TipoMovimiento Tipo,
            int IdProducto,
            int IdComprador,
            decimal Monto,
            int Unidades)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@tipo", Tipo);
            acceso.SetParametros("@IdProducto", IdProducto);
            acceso.SetParametros("@IdComprador", IdComprador);
            acceso.SetParametros("@Monto", Monto);
            acceso.SetParametros("@Unidades", Unidades);
            acceso.SetConsulta(
               "insert into MOVIMIENTOS (tipo, id_producto, id_comprador, precio, unidades)"
               + "values (@Tipo, @IdProducto, @IdComprador, @Monto, @Unidades);");
            
            int Id = acceso.EjecutarEscalar();

            acceso.CerrarConexion();

            if (Id != 0)
                return DesdeID(Id);

            return null;
        }
        public Movimiento DesdeID(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetConsulta(
                "select m.id MovimientoId, m.id_producto MovimientoProducto, m.id_usuario MovimientoUsuario, "
                + "m.tipo MovimientoTipo, m.precio MovimientoMonto, m.unidades MovimientoUnidades, "
                + "p.id_marca ProductoMarca, p.id_usuario ProductoOferente, p.nombre ProductoNombre, "
                + "p.descripcion ProductoDescripcion, p.unidades ProductoUnidades, p.precio_lista ProductoPrecio, "
                + "p.logotipo ProductoIlustracion, mm.nombre MarcaNombre, "
                + "u.nombre UsuarioNombre, u.p_admin UsuarioPermisoAdministrador, u.p_comprar UsuarioPermisoComprar,"
                + "u.p_vender UsuarioPermisoVender,"
                + "o.nombre OferenteNombre, o.p_admin OferentePermisoAdministrador, o.p_comprar OferentePermisoComprar, "
                + "o.p_vender OferentePermisoVender from MOVIMIENTOS m "
                + "left join PRODUCTOS p on m.id_producto = p.id left join USUARIOS u on m.id_usuario = u.id "
                + "left join USUARIOS o on p.id_usuario = o.id "
                + "left join MARCAS mm on p.id_marca = mm.id "
                + "where m.id = " + ID + ";");
            
            acceso.EjecutarLectura();

            if (!acceso.Lector.Read())
                return null;

            Movimiento movimiento = new Movimiento();

            movimiento.Id = Convert.ToInt32(acceso.Lector["MovimientoId"]);
            movimiento.Producto.Id = Convert.ToInt32(acceso.Lector["MovimientoProducto"]);
            movimiento.Comprador.Id = Convert.ToInt32(acceso.Lector["MovimientoUsuario"]);
            movimiento.Tipo = (TipoMovimiento)Convert.ToInt32(acceso.Lector["MovimientoTipo"]);
            movimiento.Monto = Convert.ToInt32(acceso.Lector["MovimientoMonto"]);
            movimiento.Unidades = Convert.ToInt32(acceso.Lector["MovimientoUnidades"]);
            movimiento.Producto.MarcaProducto.Id = Convert.ToInt32(acceso.Lector["ProductoMarca"]);
            movimiento.Producto.Oferente.Id = Convert.ToInt32(acceso.Lector["ProductoOferente"]);
            movimiento.Producto.Nombre = (string)acceso.Lector["ProductoNombre"];
            movimiento.Producto.Descripcion = (string)acceso.Lector["ProductoDescripcion"];
            movimiento.Producto.Unidades = Convert.ToInt32(acceso.Lector["ProductoUnidades"]);
            movimiento.Producto.PrecioLista = (decimal)acceso.Lector["ProductoPrecio"];
            movimiento.Producto.Ilustracion = new Uri((string)acceso.Lector["ProductoIlustracion"]);
            movimiento.Producto.MarcaProducto.Nombre = (string)acceso.Lector["MarcaNombre"];
            movimiento.Comprador.Nombre = (string)acceso.Lector["UsuarioNombre"];
            movimiento.Comprador.PermisoAdmin = (bool)acceso.Lector["UsuarioPermisoAdministrador"];
            movimiento.Comprador.PermisoComprar = (bool)acceso.Lector["UsuarioPermisoComprar"];
            movimiento.Comprador.PermisoVender = (bool)acceso.Lector["UsuarioPermisoVender"];
            movimiento.Producto.Oferente.Nombre = (string)acceso.Lector["OferenteNombre"];
            movimiento.Producto.Oferente.PermisoAdmin = (bool)acceso.Lector["OferentePermisoAdministrador"];
            movimiento.Producto.Oferente.PermisoComprar = (bool)acceso.Lector["OferentePermisoComprar"];
            movimiento.Producto.Oferente.PermisoVender = (bool)acceso.Lector["OferentePermisoVender"];

            return movimiento;
        }
        public void Borrar(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", ID);
            acceso.SetConsulta(
                "delete from MOVIMIENTOS where ID = @ID;");
            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public List<Movimiento> Listar()
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetConsulta(
                "select m.id MovimientoId, m.id_producto MovimientoProducto, m.id_usuario MovimientoUsuario, "
                + "m.tipo MovimientoTipo, m.precio MovimientoMonto, m.unidades MovimientoUnidades, "
                + "p.id_marca ProductoMarca, p.id_usuario ProductoOferente, p.nombre ProductoNombre, "
                + "p.descripcion ProductoDescripcion, p.unidades ProductoUnidades, p.precio_lista ProductoPrecio, "
                + "p.logotipo ProductoIlustracion, mm.nombre MarcaNombre, "
                + "u.nombre UsuarioNombre, u.p_admin UsuarioPermisoAdministrador, u.p_comprar UsuarioPermisoComprar,"
                + "u.p_vender UsuarioPermisoVender,"
                + "o.nombre OferenteNombre, o.p_admin OferentePermisoAdministrador, o.p_comprar OferentePermisoComprar, "
                + "o.p_vender OferentePermisoVender from MOVIMIENTOS m "
                + "left join PRODUCTOS p on m.id_producto = p.id left join USUARIOS u on m.id_usuario = u.id "
                + "left join USUARIOS o on p.id_usuario = o.id "
                + "left join MARCAS mm on p.id_marca = mm.id;");

            acceso.EjecutarLectura();
            
            Movimiento movimiento;
            List<Movimiento> lista = new List<Movimiento>();

            while (acceso.Lector.Read())
            {
                movimiento = new Movimiento();

                movimiento.Id = (int)acceso.Lector["MovimientoId"];
                movimiento.Producto.Id = (int)acceso.Lector["MovimientoProducto"];
                movimiento.Comprador.Id = (int)acceso.Lector["MovimientoUsuario"];
                movimiento.Tipo = (TipoMovimiento)(int)acceso.Lector["MovimientoTipo"];
                movimiento.Monto = (decimal)acceso.Lector["MovimientoMonto"];
                movimiento.Unidades = (int)acceso.Lector["MovimientoUnidades"];
                movimiento.Producto.MarcaProducto.Id = (int)acceso.Lector["ProductoMarca"];
                movimiento.Producto.Oferente.Id = (int)acceso.Lector["ProductoOferente"];
                movimiento.Producto.Nombre = (string)acceso.Lector["ProductoNombre"];
                movimiento.Producto.Descripcion = (string)acceso.Lector["ProductoDescripcion"];
                movimiento.Producto.Unidades = (int)acceso.Lector["ProductoUnidades"];
                movimiento.Producto.PrecioLista = (decimal)acceso.Lector["ProductoPrecio"];
                movimiento.Producto.Ilustracion = new Uri((string)acceso.Lector["ProductoIlustracion"]);
                movimiento.Producto.MarcaProducto.Nombre = (string)acceso.Lector["MarcaNombre"];
                movimiento.Comprador.Nombre = (string)acceso.Lector["UsuarioNombre"];
                movimiento.Comprador.PermisoAdmin = (bool)acceso.Lector["UsuarioPermisoAdministrador"];
                movimiento.Comprador.PermisoComprar = (bool)acceso.Lector["UsuarioPermisoComprar"];
                movimiento.Comprador.PermisoVender = (bool)acceso.Lector["UsuarioPermisoVender"];
                movimiento.Producto.Oferente.Nombre = (string)acceso.Lector["OferenteNombre"];
                movimiento.Producto.Oferente.PermisoAdmin = (bool)acceso.Lector["OferentePermisoAdministrador"];
                movimiento.Producto.Oferente.PermisoComprar = (bool)acceso.Lector["OferentePermisoComprar"];
                movimiento.Producto.Oferente.PermisoVender = (bool)acceso.Lector["OferentePermisoVender"];

                lista.Add(movimiento);
            }

            return lista;
        }
    }
}