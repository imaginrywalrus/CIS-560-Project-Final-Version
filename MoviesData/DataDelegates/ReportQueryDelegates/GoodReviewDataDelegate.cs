using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class GoodReviewDataDelegate : DataReaderDelegate<IReadOnlyList<(Review, Movie, int, int, int, int, int, int, int)>>
    {
        private readonly int rating;

        public GoodReviewDataDelegate(int rating)
           : base("Movies.GoodReview")
        {
            this.rating = rating;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
            var p3 = command.Parameters.Add("rating", SqlDbType.Int);
            p3.Value = rating;
        }

        public override IReadOnlyList<(Review, Movie, int, int, int, int, int, int, int)> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException((rating).ToString());
            }

            var reviewMoviePair = new List<(Review, Movie, int, int, int, int, int, int, int)>();

            while (reader.Read())
            {
                Review addReview = new Review(
                    reader.GetInt32("ReviewID"),
                    reader.GetInt32("MovieID"),
                    reader.GetInt32("ReviewerID"),
                    reader.GetInt32("Rating"),
                    reader.GetString("Review"),
                    reader.GetString("ReviewSite")
                    );
                Movie addMovie = new Movie(
                   reader.GetInt32("MovieID"),
                   reader.GetString("MovieName"),
                   reader.GetString("Genre1"),
                   reader.GetString("Genre2"),
                   reader.GetString("Genre3"),
                   reader.GetDateTime("ReleaseDate"),
                   reader.GetDouble("CostOfProduction")
                   /*
                   reader.GetString("IsRemoved"),
                   reader.GetString("CreatedOn"),
                   reader.GetString("UpdatedOn")
                   */
                   );
                reviewMoviePair.Add((addReview, addMovie, 
                    reader.GetInt32("DramaCount"), 
                    reader.GetInt32("CrimeCount"), 
                    reader.GetInt32("ActionCount"),
                    reader.GetInt32("BiographyCount"),
                    reader.GetInt32("HistoryCount"),
                    reader.GetInt32("AdventureCount"),
                    reader.GetInt32("WesternCount")));
            }

            return reviewMoviePair;
        }
    }
}