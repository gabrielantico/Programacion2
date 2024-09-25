CREATE procedure SP_Insertar_Detalle
@detalle int,
@cantidad decimal,
@articulo int,
@nro int
as
begin
Insert into detalles_facturas (id_detalle, cantidad, id_articulo, nro_factura)
values (@detalle, @cantidad, @articulo, @nro)
end

create procedure SP_Insertar_Maestro
@cliente varchar(50),
@forma int,
@nro int output
as
Begin
Insert into facturas (fecha, cliente, id_forma_pago)
values (GETDATE(), @cliente, @forma)
set @nro = SCOPE_IDENTITY()
end

create procedure SP_Actualizar_Maestro
@fecha date,
@cliente varchar(50),
@forma int,
@nroFactura int
as
begin
update facturas
set fecha = @fecha,
	cliente = @cliente,
	id_forma_pago = @forma
where nro_factura = @nroFactura
end

create procedure SP_Actualizar_Detalle
@nroDetalle int,
@cantidad decimal,
@articulo int
as
begin
update detalles_facturas
set cantidad = @cantidad,
	id_articulo = @articulo
where id_detalle = @nroDetalle
end