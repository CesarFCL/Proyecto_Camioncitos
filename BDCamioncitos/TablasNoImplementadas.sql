-- Tabla Chofer_Envio
create table CHOFER_ENVIO
(
  CI_CHOFER VARCHAR(10) not null,
  ID_ENVIO int not null,
  CONSTRAINT fk_ID_ENVIO FOREIGN KEY (ID_ENVIO) REFERENCES ENVIO (ID_FACTURA)
  ON UPDATE cascade 
  ON DELETE cascade,
  CONSTRAINT fk_CI_CHOFER_ENVIO FOREIGN KEY (CI_CHOFER) REFERENCES EMPLEADOS (CI)
  ON UPDATE cascade 
  ON DELETE cascade,
  primary key(CI_CHOFER,ID_ENVIO)
);

-- Tabla Informe
create table Informe
(
  ID VARCHAR(20) primary key,
  CI_CHOFER VARCHAR(10) not null,
  MATRICULA_VEHICULO  VARCHAR(10) not null,
  COMBUSTIBLE FLOAT not null, --Son dolares
  KILOMETRAJE FLOAT not null,
  FECHA_GESTION DATE not null,
  CONSTRAINT fk_MATRICULA_I FOREIGN KEY (MATRICULA_VEHICULO) REFERENCES VEHICULO (MATRICULA),
  CONSTRAINT fk_CI_I FOREIGN KEY (CI_CHOFER) REFERENCES EMPLEADOS (CI)
  ON UPDATE cascade
  ON DELETE cascade
);

-- Procedimiento para Obtener Facturas
CREATE PROC ObtenerPedido
@Condicion nvarchar(30)
as
begin
	SET NOCOUNT ON
	SELECT
		ID as 'ID',
		FECHA as 'Fecha',
		RUC_CLIENTE as 'RUC Cliente',
		DETALLES as 'Detalles',
		PESO as 'Peso',
		ENVIO_INTRAPROVINCIAL as 'Envio Intraprovincial',
		COSTO as 'Costo'
		FROM PEDIDO 
		where ID like @Condicion+'%' or RUC_CLIENTE like @Condicion+'%'
end
go

-- Procedimiento para Obtener Envios
CREATE PROC ObtenerEnvios
@Condicion nvarchar(30)
as
begin
	SET NOCOUNT ON
	SELECT
		ID_FACTURA as 'ID',
		DIRECCION_DESTINATARIO as 'Direccion Destinatario',
		CI_DESTINATARIO as 'CI Destinatario',
		TELEFONO_DESTINATARIO as 'Telefono Destinatario',
		CASE WHEN ESTADO = 1 then 'Finalizado' else 'Pendiente' end as 'Estado',
		FECHA_FINALIZACION as 'Fecha Finalizacion'
		FROM ENVIO
		where ID_PEDIDO like @Condicion+'%' or CI_DESTINATARIO like @Condicion+'%'
end
go

