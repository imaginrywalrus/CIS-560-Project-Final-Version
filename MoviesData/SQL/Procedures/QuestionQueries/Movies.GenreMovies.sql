CREATE OR ALTER PROCEDURE Movies.GenreMovies
   @Genre NVARCHAR(64)
AS

-- All movies that share a given genre
SELECT * --M.MovieName
FROM Movies.Movie M
Where M.Genre1 = @Genre OR M.Genre2 = @Genre OR M.Genre3 = @Genre;
GO