CREATE OR ALTER PROCEDURE Movies.TotalSales
    @MovieName NVARCHAR(32)
AS

Select M.MovieName, SUM(MC.TicketsSold * MC.TicketPrice) AS TotalSales
FROM Movies.Movie M
    INNER JOIN Movies.MovieCinema MC ON MC.MovieID = M.MovieID
WHERE M.MovieName = @MovieName
GROUP BY M.MovieName;
GO