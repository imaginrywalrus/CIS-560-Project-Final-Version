﻿CREATE OR ALTER PROCEDURE Movies.AddCinema
	@State NVARCHAR(64),
	@City NVARCHAR(64),
	@Address NVARCHAR(64),
	@CinemaID INT OUTPUT
AS

INSERT Movies.Cinema([State], City, [Address])
VALUES (@STATE, @City, @Address);

SET @CinemaID = SCOPE_IDENTITY();