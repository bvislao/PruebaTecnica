USE [BDCanvia];
GO

IF OBJECT_ID('[dbo].[usp_OrdenesDetalleSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_OrdenesDetalleSelect] 
END 
GO
CREATE PROC [dbo].[usp_OrdenesDetalleSelect] 
    @ordenDetalleId int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ordenDetalleId], [ordenId], [productoId], [cantidad], [totalPrecio], [activo] 
	FROM   [dbo].[OrdenesDetalle] 
	WHERE  ([ordenDetalleId] = @ordenDetalleId OR @ordenDetalleId IS NULL)  AND activo=1

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_OrdenesDetalleInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_OrdenesDetalleInsert] 
END 
GO
CREATE PROC [dbo].[usp_OrdenesDetalleInsert] 
    @ordenId int,
    @productoId int,
    @cantidad int,
    @totalPrecio decimal(18, 2),
    @activo bit
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[OrdenesDetalle] ([ordenId], [productoId], [cantidad], [totalPrecio], [activo])
	SELECT @ordenId, @productoId, @cantidad, @totalPrecio, @activo
 
	SELECT [ordenDetalleId], [ordenId], [productoId], [cantidad], [totalPrecio], [activo]
	FROM   [dbo].[OrdenesDetalle]
	WHERE  [ordenDetalleId] = SCOPE_IDENTITY()
	 
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_OrdenesDetalleUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_OrdenesDetalleUpdate] 
END 
GO
CREATE PROC [dbo].[usp_OrdenesDetalleUpdate] 
    @ordenDetalleId int,
    @ordenId int,
    @productoId int,
    @cantidad int,
    @totalPrecio decimal(18, 2),
    @activo bit
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[OrdenesDetalle]
	SET    [ordenId] = @ordenId, [productoId] = @productoId, [cantidad] = @cantidad, [totalPrecio] = @totalPrecio, [activo] = @activo
	WHERE  [ordenDetalleId] = @ordenDetalleId
	 
	SELECT [ordenDetalleId], [ordenId], [productoId], [cantidad], [totalPrecio], [activo]
	FROM   [dbo].[OrdenesDetalle]
	WHERE  [ordenDetalleId] = @ordenDetalleId	
	 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_OrdenesDetalleDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_OrdenesDetalleDelete] 
END 
GO
CREATE PROC [dbo].[usp_OrdenesDetalleDelete] 
    @ordenDetalleId int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[OrdenesDetalle]
	WHERE  [ordenDetalleId] = @ordenDetalleId

	COMMIT
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

