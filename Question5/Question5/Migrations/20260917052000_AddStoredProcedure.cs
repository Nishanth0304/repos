using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Question5.Migrations
{
    public partial class AddStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE sp_GetOrderDetails @OrderId INT
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
END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetOrderDetails;");
        }
    }
}
