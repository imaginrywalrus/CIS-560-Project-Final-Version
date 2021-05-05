using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class AddMovieDirectorDataDelegate : DataReaderDelegate<MovieDirector>
    {
        private readonly double salary;

        public AddMovieDirectorDataDelegate(float salary)
           : base("Movies.AddMovieDirector")
        {
            this.salary = salary;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("Salary", SqlDbType.Float);
            p.Value = salary;

            p = command.Parameters.Add("DirectorID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;

            p = command.Parameters.Add("MovieID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override MovieDirector Translate(SqlCommand command, IDataRowReader reader)
        {
            return new MovieDirector((int)command.Parameters["DirectorID"].Value, (int)command.Parameters["MovieID"].Value, salary);
        }
    }
}