CREATE OR ALTER PROCEDURE Movies.AddDirector
	@FirstName NVARCHAR(32),
	@MiddleName NVARCHAR(32),
	@LastName NVARCHAR(32)
AS

INSERT Movies.Directors(FirstName, MiddleName, LastName)
VALUES(@FirstName, @MiddleName, @LastName);