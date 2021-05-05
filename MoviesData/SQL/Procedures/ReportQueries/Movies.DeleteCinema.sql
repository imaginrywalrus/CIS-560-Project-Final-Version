CREATE OR ALTER PROCEDURE Movies.DeleteCinema
    @Address NVARCHAR(32)
AS

DELETE Movies.Reviewer
WHERE [Address] = @Address;