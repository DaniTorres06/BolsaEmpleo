USE [BolsaEmpleoDB]
GO
/****** Object:  Table [dbo].[Ciudadanos]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudadanos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumento] [int] NOT NULL,
	[Cedula] [int] NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Profesion] [varchar](100) NOT NULL,
	[AspiracionSalarial] [decimal](18, 0) NOT NULL,
	[CorreoElectronico] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocto]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumento] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VacantesOfertadas]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VacantesOfertadas](
	[IdVacante] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](6) NOT NULL,
	[Cargo] [varchar](100) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Empresa] [varchar](50) NOT NULL,
	[Salario] [decimal](18, 0) NOT NULL,
	[State] [int] NOT NULL,
	[IdCiudadano] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Ciudadanos_add]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Ciudadanos_add]	
	@TipoDocumento int,
	@Cedula int,
	@Nombres varchar(100),
	@Apellidos varchar(100),
	@FechaNacimiento datetime,
	@Profesion varchar(100),
	@AspiracionSalarial decimal(18,0),
	@CorreoElectronico varchar(100)

AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;
DECLARE @Id int = 0;

	BEGIN TRY    
	BEGIN TRAN sp_Ciudadanos_add

	INSERT INTO dbo.Ciudadanos
	(
		TipoDocumento,
		Cedula,
		Nombres,
		Apellidos,
		FechaNacimiento,
		Profesion,
		AspiracionSalarial,
		CorreoElectronico
	)
	VALUES
	(
		@TipoDocumento,
		@Cedula,
		@Nombres,
		@Apellidos,
		@FechaNacimiento,
		@Profesion,
		@AspiracionSalarial,
		@CorreoElectronico
	)

	SET @Id = (SELECT scope_identity());

	if (@Id <> 0)
	begin
		SELECT	TipoDocumento,
				Cedula,
				Nombres,
				Apellidos,
				FechaNacimiento,
				Profesion,
				AspiracionSalarial,
				CorreoElectronico,
				@HasErrors HasErrors
		FROM	dbo.Ciudadanos
		WHERE	Id = @Id
	end
	


  COMMIT TRAN sp_Ciudadanos_add
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN sp_Ciudadanos_add
  SET @HasErrors = 1;
  
  
 END CATCH  

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Ciudadanos_del]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Ciudadanos_del]
	@id int

AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;


	BEGIN TRY    
	BEGIN TRAN sp_Ciudadanos_get

	IF EXISTS(SELECT 1 FROM DBO.Ciudadanos WHERE Id = @Id)
	BEGIN
		DELETE
		FROM	dbo.Ciudadanos
		WHERE	id = @id
		
		SELECT	@HasErrors HasErrors
	END
	ELSE
	BEGIN
		SET @HasErrors = 1;
		SELECT	@HasErrors HasErrors
	END
	

  COMMIT TRAN sp_Ciudadanos_get
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN sp_Ciudadanos_get
  SET @HasErrors = 1;

  select @HasErrors HasErrors
  
 END CATCH  

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Ciudadanos_edit]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Ciudadanos_edit]
	@id int,
	@TipoDocumento int,
	@Cedula int,
	@Nombres varchar(100),
	@Apellidos varchar(100),
	@FechaNacimiento datetime,
	@Profesion varchar(100),
	@AspiracionSalarial decimal(18,0),
	@CorreoElectronico varchar(100)

AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;


	BEGIN TRY    
	BEGIN TRAN sp_Ciudadanos_edit

	UPDATE	dbo.Ciudadanos
	set		TipoDocumento = @TipoDocumento,
			Cedula = @Cedula,
			Nombres = @Nombres,
			Apellidos = @Apellidos,
			FechaNacimiento = @FechaNacimiento,
			Profesion = @Profesion,
			AspiracionSalarial = @AspiracionSalarial,
			CorreoElectronico = @CorreoElectronico
	WHERE	id = @id

	SELECT	Id,
			TipoDocumento,
			Cedula,
			Nombres,
			Apellidos,
			FechaNacimiento,
			Profesion,
			AspiracionSalarial,
			CorreoElectronico,
			@HasErrors HasErrors
	FROM	dbo.Ciudadanos
	WHERE	id = @id


  COMMIT TRAN sp_Ciudadanos_edit
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN sp_Ciudadanos_edit
  SET @HasErrors = 1;

	SELECT	1 Has_error
  
 END CATCH  

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Ciudadanos_get]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Ciudadanos_get]

AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;


	BEGIN TRY    
	BEGIN TRAN sp_Ciudadanos_get

	SELECT	Id,
			TipoDocumento,
			Cedula,
			Nombres,
			Apellidos,
			FechaNacimiento,
			Profesion,
			AspiracionSalarial,
			CorreoElectronico,
			@HasErrors HasErrors
	FROM	dbo.Ciudadanos	
	

  COMMIT TRAN sp_Ciudadanos_get
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN sp_Ciudadanos_get
  SET @HasErrors = 1;

  select @HasErrors HasErrors
  
 END CATCH  

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Ciudadanos_getId]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Ciudadanos_getId]
	@id int

AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;


	BEGIN TRY    
	BEGIN TRAN sp_Ciudadanos_get

	IF EXISTS(SELECT 1 FROM DBO.Ciudadanos WHERE Id = @Id)
	BEGIN
		SELECT	Id,
				TipoDocumento,
				Cedula,
				Nombres,
				Apellidos,
				FechaNacimiento,
				Profesion,
				AspiracionSalarial,
				CorreoElectronico,
				@HasErrors HasErrors
		FROM	dbo.Ciudadanos	
		WHERE	Id = @Id
	END
	ELSE
	BEGIN
		SET @HasErrors = 1;
		select	@HasErrors HasErrors
	END
	

  COMMIT TRAN sp_Ciudadanos_get
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN sp_Ciudadanos_get
  SET @HasErrors = 1;

  select @HasErrors HasErrors
  
 END CATCH  

END
GO
/****** Object:  StoredProcedure [dbo].[sp_TipoDocto_get]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_TipoDocto_get]	

AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;

	BEGIN TRY    
	BEGIN TRAN sp_TipoDocto_get

	IF EXISTS(SELECT 1 FROM DBO.TipoDocto)
	BEGIN
		SELECT	Id,
				TipoDocumento,				
				@HasErrors HasErrors
		FROM	dbo.TipoDocto
	END
	ELSE
	BEGIN
		SET @HasErrors = 1;
		SELECT	@HasErrors HasErrors
	END	

  COMMIT TRAN sp_TipoDocto_get
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN sp_TipoDocto_get
  SET @HasErrors = 1;

  SELECT @HasErrors HasErrors
  
 END CATCH  

END
GO
/****** Object:  StoredProcedure [dbo].[sp_vacante_fill_data]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_vacante_fill_data]
AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;

	BEGIN TRY    
	BEGIN TRAN vacante_fill_data

	IF NOT EXISTS(SELECT 1 FROM dbo.VacantesOfertadas)
	BEGIN
		insert into dbo.VacantesOfertadas values
		('RS001','Ingeniero Industrial','Se requiere Ingeniero Industrial con mínimo 2 años de experiencia en Salud Ocupacional','EPM',2500000,1,0),
		('RS002','Profesor de Química','Se requiere Químico con mínimo 3 años de experiencia en docencia.','INSTITUCIÓN EDUCATIVA IES',1900000,1,0),
		('RS003','Ingeniero de Desarrollo Junior','Se requiere Ingeniero de Sistemas con mínimo 1 año de experiencia en Desarrollo de Software en tecnología JAVA.','XRM SERVICES',2600000,1,0),
		('RS004','Coordinador de Mercadeo','Se necesita Coordinador de Mercadeo con estudios Tecnológicos graduado y experiencia mínima de un año.','INSERCOL',1350000,1,0),
		('RS005','Profesor de Matemáticas','Se requiere Licenciado en Matemáticas o Ingeniero con mínimo 2 años de experiencia en docencia.','SENA',1750000,1,0),
		('RS006','Mensajero','Se requiere mensajero con moto, con documentos al día y buenas relaciones personales','SERVIENTREGA',950000,1,0),
		('RS007','Cajero','Se requiere cajero para almacén de cadena con experiencia mínima de un año, debe disponer de tiempo por cambios de turnos.','ALMACENES ÉXITO',850000,1,0)
	END
	ELSE
	BEGIN
		SET @HasErrors = 1;
		SELECT	@HasErrors HasErrors
	END	

  COMMIT TRAN vacante_fill_data
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN vacante_fill_data
  SET @HasErrors = 1;

  SELECT @HasErrors HasErrors
  
 END CATCH  

END
GO
/****** Object:  StoredProcedure [dbo].[sp_vacantes_edit]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_vacantes_edit]
	@IdVacante int,
	@state int,
	@id_ciudadano int
AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;

	BEGIN TRY    
	BEGIN TRAN sp_vacantes_edit

	update	VacantesOfertadas
	set		State = @state,
			IdCiudadano = @id_ciudadano
	where	IdVacante = @IdVacante

  COMMIT TRAN sp_vacantes_edit
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN sp_vacantes_edit
  SET @HasErrors = 1;

  SELECT @HasErrors HasErrors
  
 END CATCH  

END
GO
/****** Object:  StoredProcedure [dbo].[sp_vacantes_get]    Script Date: 2/02/2024 4:52:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_vacantes_get]	

AS
BEGIN

SET NOCOUNT ON;
DECLARE @HasErrors INT = 0;
DECLARE @Breaker INT = 0;

	BEGIN TRY    
	BEGIN TRAN sp_vacantes_get

	IF EXISTS(SELECT 1 FROM DBO.VacantesOfertadas)
	BEGIN
		SELECT	IdVacante,
				Codigo,
				Cargo,
				Descripcion,
				Empresa,
				Salario,
				State Estado,
				IdCiudadano,
				@HasErrors HasErrors
		FROM	dbo.VacantesOfertadas
	END
	ELSE
	BEGIN
		SET @HasErrors = 1;
		SELECT	@HasErrors HasErrors
	END	

  COMMIT TRAN sp_vacantes_get
  
 END TRY  
 BEGIN CATCH
  ROLLBACK TRAN sp_vacantes_get
  SET @HasErrors = 1;

  SELECT @HasErrors HasErrors
  
 END CATCH  

END
GO
