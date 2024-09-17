create database negocio
go
use negocio
go

create table formas_pago(
id_forma_pago int,
nombre varchar(50)
constraint pk_id_forma_pago primary key (id_forma_pago)
)

create table articulos(
id_articulo int,
nombre varchar(50),
pre_unitario decimal
constraint pk_id_articulo primary key (id_articulo)
)

create table facturas(
nro_factura int identity (1, 1),
fecha date,
cliente varchar(50),
id_forma_pago int
constraint pk_nro_factura primary key (nro_factura)
constraint fk_id_forma_pago foreign key (id_forma_pago)
references formas_pago (id_forma_pago)
)

create table detalles_facturas(
id_detalle int,
nro_factura int,
cantidad decimal,
id_articulo int
constraint pk_detalle primary key (id_detalle, nro_factura)
constraint fk_id_articulo foreign key (id_articulo)
references articulos (id_articulo),
constraint fk_nro_factura foreign key (nro_factura)
references facturas (nro_factura)
)

Insert into articulos (id_articulo, pre_unitario, nombre)
values (1, 900, 'Fideos');
Insert into articulos (id_articulo, pre_unitario, nombre)
values (2, 500, 'Alfajor');
Insert into articulos (id_articulo, pre_unitario, nombre)
values (3, 150, 'Chupetín')

Insert into formas_pago(id_forma_pago, nombre)
values (1, 'Efectivo')
Insert into formas_pago(id_forma_pago, nombre)
values (2, 'Trasnferencia')
Insert into formas_pago(id_forma_pago, nombre)
values (3, 'QR')
Insert into formas_pago(id_forma_pago, nombre)
values (4, 'Tarjeta de débito')
Insert into formas_pago(id_forma_pago, nombre)
values (5, 'Tarjeta de crédito')

--create procedure SP_Insertar_Maestro
--@cliente varchar(50),
--@forma int,
--@nro int output
--as
--Begin
--Insert into facturas (fecha, cliente, id_forma_pago)
--values (GETDATE(), @cliente, @forma)
--set @nro = SCOPE_IDENTITY()
--end

--create procedure SP_Insertar_Detalle
--@detalle int,
--@cantidad decimal,
--@articulo int,
--@nro int
--as
--begin
--Insert into detalles_facturas (id_detalle, cantidad, id_articulo, nro_factura)
--values (@detalle, @cantidad, @articulo, @nro)
--end