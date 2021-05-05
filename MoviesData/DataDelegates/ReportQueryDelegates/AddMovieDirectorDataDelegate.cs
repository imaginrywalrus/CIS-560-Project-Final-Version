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
        private readonly string firstName;
        private readonly string lastName;
        private readonly string movieName;
        public AddMovieDirectorDataDelegate(double salary, string firstName, string lastName, string movieName)
           : base("Movies.AddMovieDirector")
        {
            this.salary = salary;
            this.firstName = firstName;
            this.lastName = lastName;
            this.movieName = movieName;

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("Salary", SqlDbType.Float);
            p.Value = salary;

            p = command.Parameters.Add("FirstName", SqlDbType.NVarChar);
            p.Value = firstName;

            p = command.Parameters.Add("LastName", SqlDbType.NVarChar);
            p.Value = lastName;

            p = command.Parameters.Add("MovieName", SqlDbType.NVarChar);
            p.Value = movieName;

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