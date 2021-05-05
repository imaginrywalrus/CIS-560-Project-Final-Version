CREATE OR ALTER PROCEDURE Movies.DeleteReview
    @ReviewID INT
AS

DELETE Movies.Review
WHERE ReviewID = @ReviewID