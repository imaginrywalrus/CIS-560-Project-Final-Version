using System;
using System.Collections.Generic;
using MoviesData.DataDelegates.QuestionQueryDelegates;
using MoviesData.DataDelegates.ReportQueryDelegates;
using MoviesData.Models;
using DataAccess;

namespace MoviesData
{
    public class SqlMoviesRepository: IMovieRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlMoviesRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public bool AddMovie(string MovieName)
        {
            var d = new AddMovieDataDelegate(MovieName);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Movie> DisplayMovieInfo()
        {
            var d = new DisplayMovieInfoDataDelegate();
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Movie> ActorMovie(string firstName, string lastName)
        {
            var d = new ActorMoviesDataDelegate(firstName, lastName);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Movie> DirectorMovies(string firstName, string lastName)
        {
            var d = new DirectorMoviesDataDelegate(firstName, lastName);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Movie> GenreMovies(string Genre)
        {
            var d = new GenreMoviesDataDelegate(Genre);
            return executor.ExecuteReader(d);
        }

        public double TotalSales(string moviename)
        {
            var d = new TotalSalesDataDelegate(moviename);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<(Movie, int, int)> ActorGenreMovies(string firstName, string lastName, string genre, int minScore, int maxScore)
        {
            var d = new ActorGenreMoviesDataDelegate(firstName, lastName, genre, minScore, maxScore);
            return executor.ExecuteReader(d);
        }
    }
}
