CREATE OR ALTER PROCEDURE Movies.DeleteReviewer
    @FirstName NVARCHAR(32),
    @LastName NVARCHAR(32)
AS

DELETE Movies.Reviewer
WHERE FirstName = @FirstName AND LastName = @LastName;