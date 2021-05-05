using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class AddMovieActorDataDelegate : DataReaderDelegate<MovieActor>
    {
        private readonly double salary;

        public AddMovieActorDataDelegate(float salary)
           : base("Movies.AddMovieActor")
        {
            this.salary = salary;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("Salary", SqlDbType.Float);
            p.Value = salary;

            p = command.Parameters.Add("ActorID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            
            p = command.Parameters.Add("MovieID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override MovieActor Translate(SqlCommand command, IDataRowReader reader)
        {
            return new MovieActor((int)command.Parameters["ActorID"].Value, (int)command.Parameters["MovieID"].Value, salary);
        }
    }
}