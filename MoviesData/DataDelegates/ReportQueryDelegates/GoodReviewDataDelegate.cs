using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class GoodReviewDataDelegate : DataReaderDelegate<IReadOnlyList<(Review, Movie, int[])>>
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

        public override IReadOnlyList<(Review, Movie, int[])> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.HasRows())
            {
                throw new RecordNotFoundException((rating).ToString());
            }

            var reviewMoviePair = new List<(Review, Movie, int[])>();

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
                int[] x = new int[7];
                x[0] = reader.GetInt32("DramaCount");
                x[1] = reader.GetInt32("CrimeCount");
                x[2] = reader.GetInt32("ActionCount");
                x[3] = reader.GetInt32("BiographyCount");
                x[4] = reader.GetInt32("HistoryCount");
                x[5] = reader.GetInt32("AdventureCount");
                x[6] = reader.GetInt32("WesternCount");
                reviewMoviePair.Add((addReview, addMovie, x));
            }

            return reviewMoviePair;
        }
    }
}