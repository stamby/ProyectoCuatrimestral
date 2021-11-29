
create table usuarios (
	id bigint not null identity primary key,
	nombre varchar(50) not null default 'Usuario',
	p_admin bit not null default 0,
	p_comprar bit not null default 1,
	p_vender bit not null default 1
);

create table marcas (
	id bigint not null identity primary key,
	nombre varchar(50) not null default 'Marca sin Nombre'
);

create table productos (
	id bigint not null identity primary key,
	id_marca bigint foreign key references marcas(id) not null,
	-- El usuario que lo publicó.
	id_usuario bigint foreign key references usuarios(id) not null,
	nombre varchar(50) not null default 'Producto sin título',
	descripcion varchar(1000) not null default 'El vendedor no incluyó una descripción del producto.',
	unidades bigint not null default 1,
	precio_lista money not null default 0,
	-- La URL de una imagen del producto.
	logotipo varchar(200)
);

create table movimientos (
	-- El tipo 0 es para la compra; el 1, para la venta.
	tipo bit not null default 0,
	id bigint not null identity primary key,
	id_producto bigint not null foreign key references productos(id),
	-- El que realizó el movimiento.
	id_usuario bigint foreign key references usuarios(id) not null,
	-- El precio puede cambiar, por lo que se guarda el que tenía al ocurrir el movimiento.
	precio money not null default 0,
	unidades bigint not null default 1
);
create table claves (
	id bigint not null identity primary key,
	id_usuario bigint foreign key references usuarios(id) not null,
	clave varchar(50) not null default ''
);
create trigger tr_usuarios_borrar_clave on Usuarios
after delete
as
delete from claves where id_usuario = (select id from deleted);