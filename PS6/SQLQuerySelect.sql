DROP PROCEDURE sp_productSelectID
GO

CREATE PROCEDURE [dbo].[sp_productSelectID]
@id INT
AS
SELECT *
FROM Product 
WHERE ID = @id
GO