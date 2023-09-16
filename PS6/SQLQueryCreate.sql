DROP PROCEDURE sp_productCreate
GO

CREATE PROCEDURE [dbo].[sp_productCreate]
	@name VARCHAR (50), @price VARCHAR (50), @id int OUTPUT
AS
	INSERT INTO Product (name, price) VALUES (@name, @price)
	SET @id = @@IDENTITY