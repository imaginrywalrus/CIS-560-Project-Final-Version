CREATE OR ALTER PROCEDURE Movies.AddActor
	@FirstName NVARCHAR(32),
	@MiddleName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@ActorID INT OUTPUT
AS

INSERT Movies.Actors(FirstName, MiddleName, LastName)
VALUES(@FirstName, @MiddleName, @LastName);

SET @ActorID = SCOPE_IDENTITY();