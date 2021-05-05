using System;
using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class AddMovieDataDelegate : DataReaderDelegate<Movie>
    {
        private readonly string movieName;
        private readonly string genre1;
        private readonly string genre2;
        private readonly string genre3;
        private readonly DateTime releaseDate;
        private readonly double costOfProduction;

        public AddMovieDataDelegate(string movieName, string genre1, string genre2, string genre3, DateTime releaseDate, double costOfProduction)
           : base("Movies.AddMovie")
        {
            this.movieName = movieName;
            this.genre1 = genre1;
            this.genre2 = genre2;
            this.genre3 = genre3;
            this.releaseDate = releaseDate;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("MovieName", SqlDbType.NVarChar);
            p.Value = movieName;

            p = command.Parameters.Add("Genre1", SqlDbType.NVarChar);
            p.Value = genre1;

            p = command.Parameters.Add("Genre2", SqlDbType.NVarChar);
            p.Value = genre2;

            p = command.Parameters.Add("Genre3", SqlDbType.NVarChar);
            p.Value = genre3;

            p = command.Parameters.Add("ReleaseDate", SqlDbType.DateTime);
            p.Value = releaseDate;

            p = command.Parameters.Add("CostOfProduction", SqlDbType.Float);
            p.Value = costOfProduction;

            p = command.Parameters.Add("MovieID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Movie Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Movie((int)command.Parameters["MovieID"].Value, movieName, genre1, genre2, genre3, releaseDate, costOfProduction);
        }
    }
}