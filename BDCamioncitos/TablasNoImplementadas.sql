-- Tabla Envio
create table ENVIO
(
  ID_ENVIO VARCHAR(10) primary key,
  RUC_REMITENTE  VARCHAR(10),
  DIRECCION_DESTINATARIO VARCHAR(50) not null,
  CI_DESTINATARIO VARCHAR(10) not null,
  Telefono_DESTINATARIO VARCHAR(50) not null,
  DETALLES VARCHAR(50) not null,
  CONSTRAINT fk_RUC FOREIGN KEY (RUC_REMITENTE) REFERENCES CLIENTE (RUC)
);

-- Tabla Factura
create table FACTURA
(
  ID_FACTURA VARCHAR(10) primary key,
  RUC_CLIENTE  VARCHAR(10),
  ID_ENVIO VARCHAR(10) not null,
  DETALLES VARCHAR(50) not null,
  COSTO FLOAT not null,
  CONSTRAINT fk_RUC FOREIGN KEY (RUC_CLIENTE) REFERENCES CLIENTE (RUC),
  CONSTRAINT fk_ID_ENVIO FOREIGN KEY (ID_ENVIO) REFERENCES ENVIO (ID_ENVIO)
);

-- Tabla Informe
create table Informe
(
  MATRICULA  VARCHAR(10) primary key,
  --CI CHOFER
  COMBUSTIBLE FLOAT not null, --Son dolares
  KILOMETRAJE FLOAT not null
  --ID Envios realizados
  --FECHA
);

-- Tabla Gestion_Vehiculo
create table  GESTION_VEHICULO
(
  MATRICULA  VARCHAR(10) primary key,
  COMBUSTIBLE FLOAT not null, --Son dolares
  KILOMETRAJE FLOAT not null,
  CONSTRAINT fk_MATRICULA_GV FOREIGN KEY (MATRICULA) REFERENCES VEHICULO (MATRICULA)
  ON UPDATE cascade
  ON DELETE cascade
);
go