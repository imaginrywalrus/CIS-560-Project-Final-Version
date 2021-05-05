CREATE OR ALTER PROCEDURE Movies.AddMovieDirector
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32),
   @MovieName NVARCHAR(32),
   @Salary FLOAT,
   @DirectorID INT OUTPUT,
   @MovieID INT OUTPUT
AS
/*
if exists (select * from Movies.Directors D where D.FirstName = @FirstName and D.LastName = @LastName)
    UPDATE Movies.Directors
    SET
        UpdatedOn = SYSDATETIMEOFFSET()
    WHERE FirstName = @FirstName and LastName = @LastName
*/
if not exists (select * from Movies.Directors D where D.FirstName = @FirstName and D.LastName = @LastName)
    INSERT Movies.Directors([FirstName],[LastName]) values(@FirstName, @LastName)

SET @DirectorID =
    (
        SELECT D.DirectorID
        FROM Movies.Directors D
        WHERE D.FirstName = @FirstName AND D.LastName = @LastName
    )
SET @MovieID =
    (
        SELECT M.MovieID
        FROM Movies.Movie M
        WHERE M.MovieName = @MovieName
    )

INSERT Movies.MovieDirectors(DirectorID, MovieID, Salary)
VALUES(@DirectorID, @MovieID, @Salary)