DROP PROCEDURE sp_productEdit
GO

CREATE PROCEDURE [dbo].[sp_productEdit]
@name VARCHAR (50), @price VARCHAR (50), @id INT
AS
UPDATE PRODUCT SET Name = @name, Price = @price 
WHERE ID = @id
GO