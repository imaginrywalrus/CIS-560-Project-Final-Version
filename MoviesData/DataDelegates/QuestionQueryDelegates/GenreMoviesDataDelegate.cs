using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class GenreMoviesDataDelegate : DataReaderDelegate<IReadOnlyList<Movie>>
    {
        private readonly string genre;

        public GenreMoviesDataDelegate(string genre)
           : base("Movies.GenreMovies")
        {
            this.genre = genre;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("Genre", SqlDbType.NVarChar);
            p1.Value = genre;
        }

        public override IReadOnlyList<Movie> Translate(SqlCommand command, IDataRowReader reader)
        {
            
            if (!reader.HasRows())
            {
                throw new RecordNotFoundException((genre).ToString());
            }
            

            var movies = new List<Movie>();

            while (reader.Read())
            {
                Movie addMovie = new Movie(reader.GetInt32("MovieID"),
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

            /*
            return new Movie(reader.GetInt32("MovieID"),
               reader.GetString("Genre1"),
               reader.GetString("Genre2"),
               reader.GetString("Genre3"),
               reader.GetString("ReleaseDate"),
               reader.GetValue<float>("CostOfProduction")
               //reader.GetString("IsRemoved"),
               //reader.GetString("CreatedOn"),
               //reader.GetString("UpdatedOn")
               );
            */
        }
    }
}