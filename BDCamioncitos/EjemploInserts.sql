--Insercion de Datos de Prueba

insert into CARGO values('00S','Secretaria');
go
insert into CARGO values('00C','Chofer');
go
insert into EMPLEADOS values('1719963470','Luis','Vera','9090909090',22,'luis@gmail.com','Muy muy lejos',HASHBYTES('SHA2_512','123'));
go
insert into EMPLEADOS values('1111111111','Jesus','Monserrate','1231231231',22,'jesus@gmail.com','En su casa',HASHBYTES('SHA2_512','321'));
go
insert into EMPLEADOS_CARGOS values('1719963470','00S');
go
insert into EMPLEADOS_CARGOS values('1111111111','00C');
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
insert into GESTION_VEHICULO values('ABC1234',0,0);
go
insert into GESTION_VEHICULO values('CBA4321',0,0);