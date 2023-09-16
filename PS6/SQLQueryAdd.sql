DROP PROCEDURE sp_productAdd
GO

CREATE PROCEDURE [dbo].[sp_productAdd]
	@name VARCHAR (50), @price VARCHAR (50), @productID int OUTPUT
AS
	INSERT INTO Product (name, price) VALUES (@name, @price)
	SET @productID = @@IDENTITY