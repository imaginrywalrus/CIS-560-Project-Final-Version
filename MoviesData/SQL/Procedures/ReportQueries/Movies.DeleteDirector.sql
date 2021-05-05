CREATE OR ALTER PROCEDURE Movies.DeleteDirector
    @FirstName NVARCHAR(32),
    @LastName NVARCHAR(32)
AS

DELETE Movies.Director
WHERE FirstName = @FirstName AND LastName = @LastName;