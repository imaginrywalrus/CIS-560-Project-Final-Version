CREATE OR ALTER PROCEDURE Movies.DeleteCinema
    @CinemaID INT,
    @MovieID INT
AS

DELETE Movies.Review
WHERE CinemaID = @CinemaID AND MovieID = @MovieID