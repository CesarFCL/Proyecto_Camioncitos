-- Tabla Empleados
create table EMPLEADOS
(
  CI  VARCHAR(10) primary key,
  NOMBRE VARCHAR(50) not null,
  APELLIDO VARCHAR(50) not null,
  CELULAR VARCHAR(10) not null,
  EDAD INTEGER not null,
  CORREO VARCHAR(50) not null,
  DIRECCION VARCHAR(50) not null,
  CONTRASEÑA VARBINARY(128) not null
);
go
-- Tabla Cargo
create table CARGO
(
  ID_CARGO  VARCHAR(10) primary key,
  NOMBRE VARCHAR(10)
);
go
-- Tabla Empleados_Cargos
create table EMPLEADOS_CARGOS
(
  CI  VARCHAR(10) primary key,
  ID_CARGO VARCHAR(10),
  CONSTRAINT fk_CI FOREIGN KEY (CI) REFERENCES EMPLEADOS (CI),
  CONSTRAINT fk_CARGO FOREIGN KEY (ID_CARGO) REFERENCES CARGO (ID_CARGO)
);
go
--Procedimiento Login Empleado
CREATE PROC LoginEmpleado
@CI VARCHAR(10),
@CONTRASEÑA VARCHAR(128)
as
SELECT
  E.NOMBRE as 'Nombre',
  E.APELLIDO as 'Apellido',
  E.CI as 'CI',
  C.NOMBRE as 'CARGO'
FROM Empleados E
JOIN EMPLEADOS_CARGOS E_C ON E.CI = E_C.CI
JOIN CARGO C ON E_C.ID_CARGO = C.ID_CARGO
where E.CI= @CI and E.CONTRASEÑA = HASHBYTES('SHA2_512',@CONTRASEÑA)
go
