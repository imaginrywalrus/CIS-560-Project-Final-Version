CREATE OR ALTER PROCEDURE Movies.DeleteMovieActor
    @ActorID INT,
    @MovieID INT
AS

DELETE Movies.Review
WHERE ActorID = @ActorID AND MovieID = @MovieID