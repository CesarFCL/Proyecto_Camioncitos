--Insercion de Datos de Prueba

insert into CARGO values('00S','Secretaria');
go
insert into CARGO values('00C','Chofer');
go
insert into CARGO values('00A','Admin');
go
insert into EMPLEADOS values('1719963470','Luis','Vera','9090909090','2001-03-15','luis@gmail.com','Muy muy lejos',HASHBYTES('SHA2_512','123'));
go
insert into EMPLEADOS values('1719963471','Braulio','Marcapulpo','9090909091','2001-01-22','braulio@gmail.com','En un agujero',HASHBYTES('SHA2_512','12345'));
go
insert into EMPLEADOS values('1111111111','Jesus','Monserrate','1231231231','2001-06-19','jesus@gmail.com','En su casa',HASHBYTES('SHA2_512','321'));
go
insert into EMPLEADOS values('2222222222','Cesar','Carrion','3213213213','2002-05-17','cesar@gmail.com','Marte',HASHBYTES('SHA2_512','1234'));
go
insert into EMPLEADOS_CARGOS values('1719963470','00S');
go
insert into EMPLEADOS_CARGOS values('1719963471','00S');
go
insert into EMPLEADOS_CARGOS values('1111111111','00C');
go
insert into EMPLEADOS_CARGOS values('2222222222','00A');
go
insert into DISPONIBILIDAD_CHOFER values('1111111111','1');
go
insert into CLIENTE values('123123123','Coca-Cola-Company','1231231231','coca_cola@cocacola.com','La Luna');
go
insert into VEHICULO values('ABC1234','Toyota','2017');
go
insert into VEHICULO values('CBA4321','Ferrari','2018');
go
insert into DISPONIBILIDAD_VEHICULO values('ABC1234',1);
go
insert into DISPONIBILIDAD_VEHICULO values('CBA4321',1);
go
insert into LISTADO_TIPOS_VEHICULOS values('000C1','Camioneta');
go
insert into LISTADO_TIPOS_VEHICULOS values('000C0','Camion');
go
insert into TIPOS_VEHICULOS values('ABC1234','000C1');
go
insert into TIPOS_VEHICULOS values('CBA4321','000C0');
go