CREATE OR ALTER PROCEDURE Movies.AddMovie
	@MovieName NVARCHAR(64),
	@Genre1 NVARCHAR(64),
	@Genre2 NVARCHAR(64),
	@Genre3 NVARCHAR(64),
	@ReleaseDate DATETIME2(0),
	@CostOfProduction FLOAT
AS

INSERT Movies.Movie(MovieName, Genre1, Genre2, Genre3, ReleaseDate, CostOfProduction)
VALUES(@MovieName, @Genre1, @Genre2, @Genre3, @ReleaseDate, @CostOfProduction);