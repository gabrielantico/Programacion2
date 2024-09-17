use negocio

create procedure SP_Insertar_Articulo
@id int,
@nombre varchar(50),
@precio decimal
as
begin
insert into articulos (id_articulo, nombre, pre_unitario)
values (@id, @nombre, @precio)
end

create procedure SP_Actualizar_Articulo
@id int,
@nombre varchar(50),
@precio decimal
as
begin
update articulos
set nombre = @nombre,
	pre_unitario = @precio
where id_articulo = @id
end

create procedure SP_Eliminar_Articulo
@id int
as
begin
delete articulos
where id_articulo = @id
end