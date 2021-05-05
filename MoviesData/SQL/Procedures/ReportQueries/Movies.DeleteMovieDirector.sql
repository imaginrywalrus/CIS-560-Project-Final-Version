CREATE OR ALTER PROCEDURE Movies.DeleteMovieDirector
    @DirectorID INT,
    @MovieID INT
AS

DELETE Movies.Review
WHERE DirectorID = @DirectorID AND MovieID = @MovieID