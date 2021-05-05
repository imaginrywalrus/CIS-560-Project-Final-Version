CREATE OR ALTER PROCEDURE Movies.DeleteActor
    @FirstName NVARCHAR(32),
    @LastName NVARCHAR(32)
AS

DELETE Movies.Actor
WHERE FirstName = @FirstName AND LastName = @LastName;