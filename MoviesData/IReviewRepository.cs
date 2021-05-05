using System.Collections.Generic;
using MoviesData.Models;

namespace MoviesData
{
    public interface IReviewRepository
    {
        Review AddReview(string firstName, string lastName, string movieName, int rating, string review, string reviewSite);

        IReadOnlyList<Review> DisplayReviewInfo();

        IReadOnlyList<Review> MovieReviews(string movieName);

        IReadOnlyList<Review> ScoreReviews(int score);

        IReadOnlyList<(Review, Movie, int[])> GoodReview(int score);
    }
}
