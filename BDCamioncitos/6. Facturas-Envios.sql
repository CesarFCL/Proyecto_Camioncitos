-- Tabla Factura
create table PEDIDO
(
  ID int identity(1,1) primary key,
  FECHA DATE not null,
  RUC_CLIENTE VARCHAR(13) not null,
  DETALLES VARCHAR(50) not null,
  PESO FLOAT not null,
  ENVIO_INTRAPROVINCIAL BIT not null,
  COSTO FLOAT not null,
  CONSTRAINT fk_RUC_FAC FOREIGN KEY (RUC_CLIENTE) REFERENCES CLIENTE (RUC)
  ON UPDATE cascade 
  ON DELETE cascade
);
go

-- Tabla Envio
create table ENVIO
(
  ID_PEDIDO int primary key,
  DIRECCION_DESTINATARIO VARCHAR(50) not null,
  CI_DESTINATARIO VARCHAR(10) not null,
  TELEFONO_DESTINATARIO VARCHAR(10) not null,
  ESTADO BIT not null,
  FECHA_FINALIZACION DATE,
  CONSTRAINT fk_ID_PEDIDO FOREIGN KEY (ID_PEDIDO) REFERENCES PEDIDO(ID)
  ON UPDATE cascade 
  ON DELETE cascade
);
go

-- Procedimiento para Crear Factura y Envio
CREATE PROC CrearPedidoEnvio
@FECHA VARCHAR(10),
@RUC_CLIENTE VARCHAR(13),
@DETALLES VARCHAR(50),
@PESO VARCHAR(10),
@ENVIO_INTRAPROVINCIAL VARCHAR(5),
@DIRECCION_DESTINATARIO VARCHAR(50),
@CI_DESTINATARIO VARCHAR(10),
@TELEFONO_DESTINATARIO VARCHAR(10)
as
begin
	SET NOCOUNT ON
	Declare @ExistRUC bit;
	if exists
	(
		select RUC
		from CLIENTE
		where RUC = @RUC_CLIENTE
	)
		begin
			Set @ExistRUC = 1;
			if
			(
				@ENVIO_INTRAPROVINCIAL = 'Si'
			)
				begin
					SET NOCOUNT ON
					insert into PEDIDO values(@FECHA,@RUC_CLIENTE,@DETALLES,@PESO,1, convert(float,@PESO) * 1.75);
				end
			else
				begin
					SET NOCOUNT ON
					insert into PEDIDO values(@FECHA,@RUC_CLIENTE,@DETALLES,@PESO,0, (convert(float,@PESO) * 1.75)+(7));
				end
			insert into ENVIO(ID_PEDIDO, DIRECCION_DESTINATARIO, CI_DESTINATARIO, TELEFONO_DESTINATARIO, ESTADO) values(Scope_identity(),@DIRECCION_DESTINATARIO,@CI_DESTINATARIO,@TELEFONO_DESTINATARIO,0);
		end
	else
	begin
		Set @ExistRUC = 0;
	end
	Select @ExistRUC as 'ExistRUC';
end
go

-- Procedimiento para Obtener DATOS Facturas/Envios
CREATE PROC ObtenerPedidoEnvio
@Condicion nvarchar(30)
as
begin
	SET NOCOUNT ON
	SELECT
		F.ID as 'ID',
		F.FECHA as 'Fecha',
		F.RUC_CLIENTE as 'RUC Cliente',
		F.DETALLES as 'Detalles',
		F.PESO as 'Peso',
		CASE WHEN F.ENVIO_INTRAPROVINCIAL = 1 then 'Si' else 'No' end as 'Envio Intraprovincial',
		F.COSTO as 'Costo',
		E.DIRECCION_DESTINATARIO as 'Direccion Destinatario',
		E.CI_DESTINATARIO as 'CI Destinatario',
		E.TELEFONO_DESTINATARIO as 'Telefono Destinatario',
		CASE WHEN E.ESTADO = 1 then 'Finalizado' else 'Pendiente' end as 'Estado',
		E.FECHA_FINALIZACION as 'Fecha Finalizacion'

		FROM PEDIDO F
		JOIN ENVIO E ON F.ID = E.ID_PEDIDO
		where F.ID like @Condicion+'%' or F.RUC_CLIENTE like @Condicion+'%' or E.CI_DESTINATARIO like @Condicion+'%'
end
go

--Procedimiento para Eliminar PedidoEnvio
CREATE PROC EliminarPedidoEnvio
@ID  VARCHAR(10)
as
begin
	SET NOCOUNT ON
	Declare @Finalizado bit;
	Select @Finalizado = ESTADO from ENVIO where ID_PEDIDO = @ID;
	if
	(
		@Finalizado = 0
	)
		begin
			delete from PEDIDO where ID = @ID
		end
	Select @Finalizado as 'Pedido Finalizado';
end
go

--Procedimiento para PedidoEnvio
CREATE PROC ModificarPedidoEnvio
@ID int,
@DETALLES VARCHAR(50),
@PESO VARCHAR(10),
@ENVIO_INTRAPROVINCIAL VARCHAR(5),
@DIRECCION_DESTINATARIO VARCHAR(50),
@TELEFONO_DESTINATARIO VARCHAR(10),
@ESTADO VARCHAR(10)
as
BEGIN 
     SET NOCOUNT ON 
	 Declare @PostEstado bit;
	 Select @PostEstado = ESTADO from ENVIO where ID_PEDIDO = @ID;
	 if
	 (
		@PostEstado = 0
	 )
		 begin
			SET NOCOUNT ON 
			UPDATE PEDIDO
			SET DETALLES = @DETALLES,
				PESO = @PESO,
				ENVIO_INTRAPROVINCIAL = CASE WHEN @ENVIO_INTRAPROVINCIAL = 'Si' then 1 else 0 end
			WHERE ID = @ID
			if
			(
				@ENVIO_INTRAPROVINCIAL = 'Si'
			)
				begin
					SET NOCOUNT ON
					UPDATE PEDIDO
					SET COSTO = (convert(float,@PESO) * 1.75)
					WHERE ID = @ID
				end
			else
				begin
					SET NOCOUNT ON
					UPDATE PEDIDO
					SET COSTO = (convert(float,@PESO) * 1.75)+(7)
					WHERE ID = @ID
				end
			UPDATE ENVIO
			SET	DIRECCION_DESTINATARIO = @DIRECCION_DESTINATARIO,
					TELEFONO_DESTINATARIO = @TELEFONO_DESTINATARIO,
					ESTADO = CASE WHEN @ESTADO = 'Finalizado' then 1 else 0 end
			WHERE ID_PEDIDO = @ID
			if
			(
				@ESTADO = 'Finalizado'
			)
			begin
				UPDATE ENVIO
				SET	FECHA_FINALIZACION = CAST(GETDATE() AS Date)
				WHERE ID_PEDIDO = @ID
			end
		 end
	 else
		 begin
			select @PostEstado as 'PostEstado';
		 end
END 
go