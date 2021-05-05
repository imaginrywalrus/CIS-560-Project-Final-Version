CREATE OR ALTER PROCEDURE Movies.AddDirector
	@FirstName NVARCHAR(32),
	@MiddleName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@DirectorID INT OUTPUT
AS

INSERT Movies.Directors(FirstName, MiddleName, LastName)
VALUES(@FirstName, @MiddleName, @LastName);

SET @DirectorID = SCOPE_IDENTITY();