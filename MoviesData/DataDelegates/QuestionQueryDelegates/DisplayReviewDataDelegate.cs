using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class DisplayReviewDataDelegate : DataReaderDelegate<IReadOnlyList<Review>>
    {
        public DisplayReviewDataDelegate()
            : base("Movies.DisplayReviewInfo")
        {

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
        }

        public override IReadOnlyList<Review> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.HasRows())
            {
                return null;
            }

            var review = new List<Review>();

            while (reader.Read())
            {
                Review addReview = new Review(
                   reader.GetInt32("ReviewID"),
                   reader.GetInt32("MovieID"),
                   reader.GetInt32("ReviewerID"),
                   reader.GetInt32("Rating"),
                   reader.GetString("Review"),
                   reader.GetString("ReviewSite")
                   /*
                   reader.GetString("IsRemoved"),
                   reader.GetString("CreatedOn"),
                   reader.GetString("UpdatedOn")
                   */
                   );
                review.Add(addReview);
            }

            return review;
        }
    }
}
