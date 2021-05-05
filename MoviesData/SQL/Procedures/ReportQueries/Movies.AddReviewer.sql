CREATE OR ALTER PROCEDURE Movies.AddReviewer
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@ReviewerID INT OUTPUT
AS

INSERT Movies.Reviewer(FirstName, LastName)
VALUES(@FirstName, @LastName);

SET @ReviewerID = SCOPE_IDENTITY();

