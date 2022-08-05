USE [BDCanvia];
GO

IF OBJECT_ID('[dbo].[usp_OrdenesSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_OrdenesSelect] 
END 
GO
CREATE PROC [dbo].[usp_OrdenesSelect] 
    @ordenId int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ordenId], [clienteId], [ordenEstado], [fechaOrden], [fechaEnvio], [precioEnvio], [subTotal], [totalOrden], [activo] 
	FROM   [dbo].[Ordenes] 
	WHERE  ([ordenId] = @ordenId OR @ordenId IS NULL) AND [activo] = 1

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_OrdenesInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_OrdenesInsert] 
END 
GO
CREATE PROC [dbo].[usp_OrdenesInsert] 
    @clienteId int,
    @ordenEstado varchar(20),
    @fechaOrden datetime = NULL,
    @fechaEnvio datetime = NULL,
    @precioEnvio decimal(18, 2),
    @subTotal decimal(18, 2),
    @totalOrden decimal(18, 2),
    @activo bit
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Ordenes] ([clienteId], [ordenEstado], [fechaOrden], [fechaEnvio], [precioEnvio], [subTotal], [totalOrden], [activo])
	SELECT @clienteId, @ordenEstado, @fechaOrden, @fechaEnvio, @precioEnvio, @subTotal, @totalOrden, @activo
	
	 
	SELECT   SCOPE_IDENTITY() AS [ordenId]
	 
               
	COMMIT
GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

