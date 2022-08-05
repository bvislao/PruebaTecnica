USE [BDCanvia];
GO

IF OBJECT_ID('[dbo].[usp_ClienteSelectALL]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ClienteSelectALL] 
END 
GO
CREATE PROC [dbo].[usp_ClienteSelectALL] 
 
AS 
	 

	BEGIN TRAN

	SELECT [clienteId], [nombre], [apellidos], [telefono], [correoElectronico], [documentoIdentidad], [activo] 
	FROM   [dbo].[Cliente] 
	WHERE    [activo] = 1

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ClienteSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ClienteSelect] 
END 
GO
CREATE PROC [dbo].[usp_ClienteSelect] 
    @clienteId int
AS 
	 

	BEGIN TRAN

	SELECT [clienteId], [nombre], [apellidos], [telefono], [correoElectronico], [documentoIdentidad], [activo] 
	FROM   [dbo].[Cliente] 
	WHERE  ([clienteId] = @clienteId OR @clienteId IS NULL)  AND [activo] = 1

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ClienteInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ClienteInsert] 
END 
GO
CREATE PROC [dbo].[usp_ClienteInsert] 
    @nombre varchar(200),
    @apellidos varchar(200),
    @telefono varchar(50) = NULL,
    @correoElectronico varchar(100) = NULL,
    @documentoIdentidad varchar(12),
    @activo bit
AS 
 
	
	BEGIN TRAN
	
	IF NOT EXISTS (SELECT 1 FROM [dbo].[Cliente] WHERE [documentoIdentidad] = @documentoIdentidad)
		BEGIN
			INSERT INTO [dbo].[Cliente] ([nombre], [apellidos], [telefono], [correoElectronico], [documentoIdentidad], [activo])
			SELECT @nombre, @apellidos, @telefono, @correoElectronico, @documentoIdentidad, @activo
	
 
			SELECT SCOPE_IDENTITY() as ID
	 END
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ClienteUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ClienteUpdate] 
END 
GO
CREATE PROC [dbo].[usp_ClienteUpdate] 
    @clienteId int,
    @nombre varchar(200),
    @apellidos varchar(200),
    @telefono varchar(50) = NULL,
    @correoElectronico varchar(100) = NULL,
    @documentoIdentidad varchar(12),
    @activo bit
AS 
	 
	
	BEGIN TRAN

	UPDATE [dbo].[Cliente]
	SET    [nombre] = @nombre, [apellidos] = @apellidos, [telefono] = @telefono, [correoElectronico] = @correoElectronico, [documentoIdentidad] = @documentoIdentidad, [activo] = @activo
	WHERE  [clienteId] = @clienteId
	 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ClienteDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ClienteDelete] 
END 
GO
CREATE PROC [dbo].[usp_ClienteDelete] 
    @clienteId int
AS 
	 
	
	BEGIN TRAN

	UPDATE [dbo].[Cliente]
	SET [activo] = 0
	WHERE  [clienteId] = @clienteId

	COMMIT
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

