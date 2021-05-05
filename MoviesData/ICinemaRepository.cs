using System;
using System.Collections.Generic;
using MoviesData.Models;


namespace MoviesData
{
    public interface ICinemaRepository
    {

        Cinema AddCinema(string state, string city, string address);
        IReadOnlyList<Cinema> DisplayCinemaInfo();

        IReadOnlyList<Cinema> StateCinemas(string state);

        IReadOnlyList<(Cinema, string, double, double)> ShowingInfo(string state);
    }
}
