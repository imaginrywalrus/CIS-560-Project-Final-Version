﻿using System;
using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class AddMovieCinemaDataDelegate : DataReaderDelegate<MovieCinema>
    {
        private readonly DateTime playingTime;
        private readonly double ticketsSold;
        private readonly double ticketPrice;

        public AddMovieCinemaDataDelegate(DateTime playingTime, double ticketsSold, double ticketPrice, int rating, string review, string reviewSite)
           : base("Movies.AddMovieCinema")
        {
            this.playingTime = playingTime;
            this.ticketsSold = ticketsSold;
            this.ticketPrice = ticketPrice;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("PlayingTime", SqlDbType.DateTime2);
            p.Value = playingTime;

            p = command.Parameters.Add("TicketsSold", SqlDbType.Float);
            p.Value = ticketsSold;

            p = command.Parameters.Add("TicketPrice", SqlDbType.Float);
            p.Value = ticketPrice;

            p = command.Parameters.Add("MovieID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;

            p = command.Parameters.Add("CinemaID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override MovieCinema Translate(SqlCommand command, IDataRowReader reader)
        {
            return new MovieCinema((int)command.Parameters["CinemaID"].Value, (int)command.Parameters["MovieID"].Value, playingTime, ticketsSold, ticketPrice);
        }
    }
}