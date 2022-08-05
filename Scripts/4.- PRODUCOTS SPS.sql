USE [BDCanvia];
GO
IF OBJECT_ID('[dbo].[usp_ProductosSelectALL]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ProductosSelectALL] 
END 
GO
CREATE PROC [dbo].[usp_ProductosSelectALL] 
     
AS 
	 
	BEGIN TRAN

	SELECT [productoId], [nombreProducto], [precioVenta], [precioEnvioMinimo], [activo] 
	FROM   [dbo].[Productos] 
	WHERE  [activo] = 1

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ProductosSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ProductosSelect] 
END 
GO
CREATE PROC [dbo].[usp_ProductosSelect] 
    @productoId int
AS 
	 
	BEGIN TRAN

	SELECT [productoId], [nombreProducto], [precioVenta], [precioEnvioMinimo], [activo] 
	FROM   [dbo].[Productos] 
	WHERE  ([productoId] = @productoId OR @productoId IS NULL) AND [activo] = 1

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ProductosInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ProductosInsert] 
END 
GO
CREATE PROC [dbo].[usp_ProductosInsert] 
    @nombreProducto varchar(100),
    @precioVenta decimal(18, 2),
    @precioEnvioMinimo decimal(18, 2),
    @activo bit
AS 
	 
	BEGIN TRAN
	
	INSERT INTO [dbo].[Productos] ([nombreProducto], [precioVenta], [precioEnvioMinimo], [activo])
	SELECT @nombreProducto, @precioVenta, @precioEnvioMinimo, @activo
	
	-- Begin Return Select <- do not remove
	SELECT [productoId], [nombreProducto], [precioVenta], [precioEnvioMinimo], [activo]
	FROM   [dbo].[Productos]
	WHERE  [productoId] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ProductosUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ProductosUpdate] 
END 
GO
CREATE PROC [dbo].[usp_ProductosUpdate] 
    @productoId int,
    @nombreProducto varchar(100),
    @precioVenta decimal(18, 2),
    @precioEnvioMinimo decimal(18, 2),
    @activo bit
AS 
	
	
	
	BEGIN TRAN

	UPDATE [dbo].[Productos]
	SET    [nombreProducto] = @nombreProducto, [precioVenta] = @precioVenta, [precioEnvioMinimo] = @precioEnvioMinimo, [activo] = @activo
	WHERE  [productoId] = @productoId
	
	-- Begin Return Select <- do not remove
	SELECT [productoId], [nombreProducto], [precioVenta], [precioEnvioMinimo], [activo]
	FROM   [dbo].[Productos]
	WHERE  [productoId] = @productoId	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ProductosDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ProductosDelete] 
END 
GO
CREATE PROC [dbo].[usp_ProductosDelete] 
    @productoId int
AS 

	
	BEGIN TRAN

	UPDATE [dbo].[Productos]
	SET  [activo] = 0
	WHERE  [productoId] = @productoId

	COMMIT
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

