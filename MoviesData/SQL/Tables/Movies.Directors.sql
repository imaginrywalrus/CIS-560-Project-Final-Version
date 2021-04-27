CREATE TABLE Movies.Directors
(
   DirectorID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   FirstName NVARCHAR(32) NOT NULL,
   MiddleName NVARCHAR(32),
   LastName NVARCHAR(32) NOT NULL,
   IsRemoved INT NOT NULL DEFAULT(0),
   CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
   UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);