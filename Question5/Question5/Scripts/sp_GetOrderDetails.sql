-- Stored procedure to get order information, user info and product details for a given order
IF OBJECT_ID('dbo.sp_GetOrderDetails', 'P') IS NOT NULL
	DROP PROCEDURE dbo.sp_GetOrderDetails;
GO

CREATE PROCEDURE dbo.sp_GetOrderDetails @OrderId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		o.OrderId,
		o.OrderDate,
		u.UserId,
		u.Name,
		u.Email,
		p.ProductId,
		p.ProductName,
		p.Price
	FROM Orders o
	INNER JOIN Users u ON o.UserId = u.UserId
	INNER JOIN OrderProduct op ON o.OrderId = op.OrdersOrderId
	INNER JOIN Products p ON op.ProductsProductId = p.ProductId
	WHERE o.OrderId = @OrderId;
END
GO
