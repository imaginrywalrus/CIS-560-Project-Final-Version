using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class AddReviewerDataDelegate : DataReaderDelegate<Reviewer>
    {
        private readonly string firstName;
        private readonly string lastName;

        public AddReviewerDataDelegate(string firstName, string lastName)
           : base("Movies.AddReviewer")
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("FirstName", SqlDbType.NVarChar);
            p.Value = firstName;

            p = command.Parameters.Add("LastName", SqlDbType.NVarChar);
            p.Value = lastName;

            p = command.Parameters.Add("ReviewerID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Reviewer Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Reviewer((int)command.Parameters["ReviewerID"].Value, firstName, lastName);
        }
    }
}