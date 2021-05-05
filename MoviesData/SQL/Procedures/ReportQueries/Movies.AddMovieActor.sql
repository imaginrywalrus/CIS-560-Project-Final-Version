CREATE OR ALTER PROCEDURE Movies.AddMovieActor
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32),
   @MovieName NVARCHAR(32),
   @Salary FLOAT,
   @ActorID INT OUTPUT,
   @MovieID INT OUTPUT
AS
/*
if exists (select * from Movies.Directors D where D.FirstName = @FirstName and D.LastName = @LastName)
    UPDATE Movies.Directors
    SET
        UpdatedOn = SYSDATETIMEOFFSET()
    WHERE FirstName = @FirstName and LastName = @LastName
*/
if not exists (select * from Movies.Actors D where D.FirstName = @FirstName and D.LastName = @LastName)
    INSERT Movies.Actors([FirstName],[LastName]) values(@FirstName, @LastName)

SET @ActorID =
    (
        SELECT A.ActorID
        FROM Movies.Actors A
        WHERE A.FirstName = @FirstName AND A.LastName = @LastName
    )
SET @MovieID =
    (
        SELECT M.MovieID
        FROM Movies.Movie M
        WHERE M.MovieName = @MovieName
    )

INSERT Movies.MovieActor(ActorID, MovieID, Salary)
VALUES(@ActorID, @MovieID, @Salary)