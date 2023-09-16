
CREATE PROCEDURE [dbo].[sp_productDelete]
@id INT
AS
DELETE FROM pracownicy
WHERE ID = @id