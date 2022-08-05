USE [BDCanvia];
GO


IF OBJECT_ID('[dbo].[usp_UsuarioLogin]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsuarioLogin] 
END 
GO
 
CREATE PROC [dbo].[usp_UsuarioLogin] (
	 @documentoIdentidad varchar(12),
	 @passwordUsuario varchar(100)= '')
	 as 
	 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [documentoIdentidad], [usuarioId], [passwordUsuario], [nombre], [apellidos], [telefono], [correoElectronico], [activo] 
	FROM   [dbo].[Usuarios] 
	WHERE  ([documentoIdentidad] = @documentoIdentidad)  AND ([passwordUsuario] = @passwordUsuario or passwordUsuario is null)

	COMMIT
 
GO
IF OBJECT_ID('[dbo].[usp_UsuariosSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsuariosSelect] 
END 
GO
CREATE PROC [dbo].[usp_UsuariosSelect] 
    @documentoIdentidad varchar(12)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [documentoIdentidad], [usuarioId], [passwordUsuario], [nombre], [apellidos], [telefono], [correoElectronico], [activo] 
	FROM   [dbo].[Usuarios] 
	WHERE  ([documentoIdentidad] = @documentoIdentidad OR @documentoIdentidad IS NULL)  AND [activo] = 1

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_UsuariosInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsuariosInsert] 
END 
GO
CREATE PROC [dbo].[usp_UsuariosInsert] 
    @documentoIdentidad varchar(12),
    @passwordUsuario varchar(100),
    @nombre varchar(200),
    @apellidos varchar(200),
    @telefono varchar(50) = NULL,
    @correoElectronico varchar(100) = NULL,
    @activo bit
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Usuarios] ([documentoIdentidad], [passwordUsuario], [nombre], [apellidos], [telefono], [correoElectronico], [activo])
	SELECT @documentoIdentidad, @passwordUsuario, @nombre, @apellidos, @telefono, @correoElectronico, @activo
	
	-- Begin Return Select <- do not remove
	SELECT [documentoIdentidad], [usuarioId], [passwordUsuario], [nombre], [apellidos], [telefono], [correoElectronico], [activo]
	FROM   [dbo].[Usuarios]
	WHERE  [documentoIdentidad] = @documentoIdentidad
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_UsuariosUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsuariosUpdate] 
END 
GO
CREATE PROC [dbo].[usp_UsuariosUpdate] 
    @documentoIdentidad varchar(12),
    @usuarioId int,
    @passwordUsuario varchar(100),
    @nombre varchar(200),
    @apellidos varchar(200),
    @telefono varchar(50) = NULL,
    @correoElectronico varchar(100) = NULL,
    @activo bit
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Usuarios]
	SET    [passwordUsuario] = @passwordUsuario, [nombre] = @nombre, [apellidos] = @apellidos, [telefono] = @telefono, [correoElectronico] = @correoElectronico, [activo] = @activo
	WHERE  [documentoIdentidad] = @documentoIdentidad
	
	-- Begin Return Select <- do not remove
	SELECT [documentoIdentidad], [usuarioId], [passwordUsuario], [nombre], [apellidos], [telefono], [correoElectronico], [activo]
	FROM   [dbo].[Usuarios]
	WHERE  [documentoIdentidad] = @documentoIdentidad	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_UsuariosDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsuariosDelete] 
END 
GO
CREATE PROC [dbo].[usp_UsuariosDelete] 
    @documentoIdentidad varchar(12)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Usuarios]
	SET [activo] = 0
	WHERE  [documentoIdentidad] = @documentoIdentidad

	COMMIT
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

