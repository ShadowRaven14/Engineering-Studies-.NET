DROP PROCEDURE sp_productDelete
GO

CREATE PROCEDURE [dbo].[sp_productDelete]
@name VARCHAR (50), @price VARCHAR(50), @id INT
AS
DELETE FROM pracownicy
WHERE ID = @id
GO