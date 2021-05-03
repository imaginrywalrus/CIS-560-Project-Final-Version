CREATE OR ALTER PROCEDURE Movies.AllMovieInfo
    @MovieName NVARCHAR(32)
AS

-- For the given movie return all information about the movie
Select 
    D.ActorID AS StartActorID,
    D.FirstName AS StartFirstName,
    D.MiddleName AS StartMiddleName,
    D.LastName AS StartLastName,
    A.ActorID AS EndActorID,
    A.FirstName AS EndFirstName,
    A.MiddleName AS EndMiddleName,
    A.LastName AS EndLastName,
    M.MovieID AS MovieID, 
    M.MovieName AS MovieName,
    M.Genre1 AS Genre1,
    M.Genre2 AS Genre2,
    M.Genre3 AS Genre3,
    M.ReleaseDate AS ReleaseDate,
    M.CostOfProduction AS CostOfProduction
    FROM Movies.Movie M
        INNER JOIN Movies.MovieCinema MC ON MC.MovieID = M.MovieID
            INNER JOIN Movies.Cinema C ON C.CinemaID = MC.CinemaID
        INNER JOIN Movies.MovieActor MA ON MA.MovieID = M.MovieID
            INNER JOIN Movies.Actors A ON A.ActorID = MA.ActorID
        INNER JOIN Movies.MovieDirectors MD ON MD.MovieID = M.MovieID
            INNER JOIN Movies.Directors D ON D.DirectorID = MD.DirectorID
        INNER JOIN Movies.Review MR ON MR.MovieID = M.MovieID
            INNER JOIN Movies.Reviewer R ON R.ReviewerID = MR.ReviewerID
WHERE M.MovieName = @MovieName
--Order BY D.ActorID;
GO