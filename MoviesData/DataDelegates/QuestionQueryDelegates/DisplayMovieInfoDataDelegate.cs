using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class DisplayMovieInfoDataDelegate : DataReaderDelegate<IReadOnlyList<Movie>>
    {
        public DisplayMovieInfoDataDelegate()
            : base("Movies.DisplayMovieInfo")
        {

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
        }

        public override IReadOnlyList<Movie> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.HasRows())
            {
                return null;
            }

            var movies = new List<Movie>();

            while (reader.Read())
            {
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
                movies.Add(addMovie);
            }

            return movies;
        }
    }
}
