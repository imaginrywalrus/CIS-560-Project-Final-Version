using System;
using System.Collections.Generic;
using MoviesData.Models;



namespace MoviesData
{
    public interface IMovieRepository
    {
        IReadOnlyList<Movie> ActorMovie(string firstName, string lastName);

        IReadOnlyList<Movie> DirectorMovies(string firstName, string lastName);

        IReadOnlyList<Movie> GenreMovies(string Genre);

        int TotalSales(string moviename);

        IReadOnlyList<(Movie, int, int, string)> ActorGenreMovies(string firstName, string lastName, string genre, int minScore, int maxScore);
    }
}
