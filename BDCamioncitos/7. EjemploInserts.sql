--Insercion de Datos de Prueba

insert into CARGO values('00S','Secretaria');
go
insert into CARGO values('00C','Chofer');
go
insert into CARGO values('00A','Admin');
go
exec CrearEmpleado '1719963470','Luis','Vera','9090909090','2001-03-15','luis@gmail.com','Muy muy lejos','123','Secretaria'
go
exec CrearEmpleado '1719963471','Braulio','Marcapulpo','9090909091','2001-01-22','braulio@gmail.com','En un agujero','12345','Secretaria'
go
exec CrearEmpleado '1111111111','Jesus','Monserrate','1231231231','2001-06-19','jesus@gmail.com','En su casa','321','Chofer'
go
exec CrearEmpleado '2222222222','Cesar','Carrion','3213213213','2002-05-17','cesar@gmail.com','Marte','1234','Admin'
go
insert into CLIENTE values('123123123','Coca-Cola-Company','1231231231','coca_cola@cocacola.com','La Luna');
go
insert into LISTADO_TIPOS_VEHICULOS values('000C1','Camioneta');
go
insert into LISTADO_TIPOS_VEHICULOS values('000C0','Camion');
go
exec CrearVehiculo 'ABC1234','Toyota','2017','Camioneta'
go
exec CrearVehiculo 'CBA4321','Ferrari','2018','Camion'
go
exec CrearPedidoEnvio '2022-08-29','123123123','5 paquetes de 6 Cocacolas de 5L','50','No','Muy lejos','1234567890','0990634712'
go