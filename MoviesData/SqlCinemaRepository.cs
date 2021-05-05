using System;
using System.Collections.Generic;
using MoviesData.DataDelegates.QuestionQueryDelegates;
using MoviesData.DataDelegates.ReportQueryDelegates;
using MoviesData.Models;
using DataAccess;

namespace MoviesData
{
    public class SqlCinemaRepository: ICinemaRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlCinemaRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public Cinema AddCinema(string state, string city, string address)
        {
            var d = new AddCinemaDataDelegate(state, city, address);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Cinema> DisplayCinemaInfo()
        {
            var d = new DisplayCinemaDataDelegate();
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<(Cinema, string, double, double)> ShowingInfo(string state)
        {
            var d = new ShowingInfoDataDelegate(state);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Cinema> StateCinemas(string state)
        {
            var d = new StateCinemasDataDelegate(state);
            return executor.ExecuteReader(d);
        }

        public MovieCinema AddMovieCinema(string address, string movieName, DateTime playingTime, double ticketsSold, double ticketPrice)
        {
            var d = new AddMovieCinemaDataDelegate(address, movieName, playingTime, ticketsSold, ticketPrice);
            return executor.ExecuteReader(d);
        }
    }
}
