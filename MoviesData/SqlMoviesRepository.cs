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
        
        public Movie AddMovie(string movieName, string genre1, string genre2, string genre3, DateTime releaseDate, double costOfProduction)
        {
            var d = new AddMovieDataDelegate(movieName, genre1, genre2, genre3, releaseDate, costOfProduction);
            return executor.ExecuteReader(d);
        }

        public MovieActor AddMovieActor(double salary, string firstName, string lastName, string movieName)
        {
            var d = new AddMovieActorDataDelegate(salary, firstName, lastName, movieName);
            return executor.ExecuteReader(d);
        }

        public MovieDirector AddMovieDirector(double salary, string firstName, string lastName, string movieName)
        {
            var d = new AddMovieDirectorDataDelegate(salary, firstName, lastName, movieName);
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
