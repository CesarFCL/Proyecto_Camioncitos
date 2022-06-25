--Insercion de Datos de Ejemplo

insert into CARGO values('00S','Secretaria');
go
insert into EMPLEADOS values('1234567890','Luis','Vera','9090909090',22,'luis@gmail.com','Muy muy lejos',HASHBYTES('SHA2_512','123'));
go
insert into EMPLEADOS_CARGOS values('1234567890','00S');
go
insert into CLIENTE values('123123123','Coca-Cola-Company','1231231231','coca_cola@cocacola.com','La Luna')
go
