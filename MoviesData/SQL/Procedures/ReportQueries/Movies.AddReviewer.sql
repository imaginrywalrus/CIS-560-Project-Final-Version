CREATE OR ALTER PROCEDURE Movies.AddReviewer
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@ReviewerID INT OUTPUT
AS

INSERT Movies.Reviewers(FirstName, LastName)
VALUES(@FirstName, @LastName);

SET @ReivewerID = SCOPE_IDENTITY();

