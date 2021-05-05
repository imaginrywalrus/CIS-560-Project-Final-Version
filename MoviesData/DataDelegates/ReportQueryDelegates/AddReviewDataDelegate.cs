using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class AddReviewDataDelegate : DataReaderDelegate<Review>
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly string movieName;
        private readonly int rating;
        private readonly string review;
        private readonly string reviewSite;

        public AddReviewDataDelegate(string firstName, string lastName, string movieName, int rating, string review, string reviewSite)
           : base("Movies.AddReview")
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.movieName = movieName;
            this.rating = rating;
            this.review = review;
            this.reviewSite = reviewSite;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("FirstName", SqlDbType.NVarChar);
            p.Value = firstName;

            p = command.Parameters.Add("LastName", SqlDbType.NVarChar);
            p.Value = lastName;

            p = command.Parameters.Add("MovieName", SqlDbType.NVarChar);
            p.Value = movieName;

            p = command.Parameters.Add("Rating", SqlDbType.Int);
            p.Value = rating;
            
            p = command.Parameters.Add("Review", SqlDbType.NVarChar);
            p.Value = review;
            
            p = command.Parameters.Add("ReviewSite", SqlDbType.NVarChar);
            p.Value = reviewSite;

            p = command.Parameters.Add("ReviewerID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;

            p = command.Parameters.Add("MovieID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;

            p = command.Parameters.Add("ReviewID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Review Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Review((int)command.Parameters["ReviewID"].Value, (int)command.Parameters["MovieID"].Value, (int)command.Parameters["ReviewerID"].Value, rating, review, reviewSite);
        }
    }
}