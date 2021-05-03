using System;
using System.Collections.Generic;
using MoviesData.Models;



namespace MoviesData
{
    public interface IMovieRepository
    {
        IReadOnlyList<Movie> DisplayMovieInfo();

        IReadOnlyList<Movie> ActorMovie(string firstName, string lastName);

        IReadOnlyList<Movie> DirectorMovies(string firstName, string lastName);

        IReadOnlyList<Movie> GenreMovies(string Genre);

        double TotalSales(string moviename);

        IReadOnlyList<(Movie, int, int)> ActorGenreMovies(string firstName, string lastName, string genre, int minScore, int maxScore);
    }
}
