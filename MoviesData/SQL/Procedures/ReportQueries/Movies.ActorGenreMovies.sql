CREATE OR ALTER PROCEDURE Movies.ActorGenreMovies
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32),
   @Genre NVARCHAR(64),
   @RatingMax INT,
   @RatingMin INT
AS

-- For a given actor, show all movies they were in that was a certain genre and in a given range of review scores along with 
DECLARE @ActorID INT = (Select A.ActorID FROM Movies.Actors A WHERE A.FirstName = @FirstName AND A.LastName = @LastName);
DECLARE @Genre NVARCHAR(64) = @Genre
DECLARE @HighScore INT = @RatingMax
DECLARE @LowScore INT = @RatingMin

SELECT
    M.MovieID AS MovieID, 
    M.MovieName AS MovieName,
    M.Genre1 AS Genre1,
    M.Genre2 AS Genre2,
    M.Genre3 AS Genre3,
    M.ReleaseDate AS ReleaseDate,
    M.CostOfProduction AS CostOfProduction,
    COUNT(DISTINCT R.Review) AS TotalReviews,
    R.Review AS Review,
    R.Rating,
    R.ReviewSite
FROM Movies.Actors A
    INNER JOIN Movies.MovieActor MA on MA.ActorID = @ActorID
    INNER JOIN Movies.Movie M ON M.MovieID = MA.MovieID
    INNER JOIN Movies.Review R ON R.MovieID = M.MovieID
WHERE (M.Genre1 = @Genre OR M.Genre2 = @Genre OR M.Genre3 = @Genre) AND (R.Rating <= @HighScore AND R.Rating >= @LowScore)
GROUP BY M.MovieName, R.Rating, R.ReviewSite
ORDER BY M.MovieName, R.ReviewSite, R.Rating;
GO