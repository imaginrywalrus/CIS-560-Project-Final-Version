CREATE OR ALTER PROCEDURE Movies.AddReviewer
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32)
AS

INSERT Movies.Reviewers(FirstName, LastName)
VALUES(@FirstName, @LastName);