CREATE OR ALTER PROCEDURE Movies.AddMovieCinema
	@Address NVARCHAR(32),
	@MovieName NVARCHAR(32),
	@PlayingTime DATETIME2(0),
	@TicketsSold FLOAT,
	@TicketPrice FLOAT,
	@CinemaID INT OUTPUT,
	@MovieID INT OUTPUT
AS
/*
if exists (select * from Movies.Directors D where D.FirstName = @FirstName and D.LastName = @LastName)
    UPDATE Movies.Directors
    SET
        UpdatedOn = SYSDATETIMEOFFSET()
    WHERE FirstName = @FirstName and LastName = @LastName
*/
if not exists (select * from Movies.Cinema C where C.[Address] = @Address)
    INSERT Movies.Cinema([Address]) values(@Address)

SET @CinemaID =
    (
        SELECT C.CinemaID
        FROM Movies.Cinema C
        WHERE C.Address = @Address
    )
SET @MovieID =
    (
        SELECT M.MovieID
        FROM Movies.Movie M
        WHERE M.MovieName = @MovieName
    )

INSERT Movies.MovieCinema(CinemaID, MovieID, PlayingTime, TicketsSold, TicketPrice)
VALUES(@CinemaID, @MovieID, @PlayingTime, @TicketsSold, @TicketPrice)