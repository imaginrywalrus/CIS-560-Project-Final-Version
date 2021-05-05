using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Models
{
    public class MovieCinema
    {
        public int CinemaID { get; }
        public int MovieID { get; }
        public DateTime PlayingTime { get; }
        public double TicketsSold { get; }
        public double TicketPrice { get; }

        //public int IsRemoved { get; }
        //public DateTime CreatedOn { get; }
        //public DateTime UpdatedOn { get; }

        public MovieCinema(int CinemaID, int MovieID, DateTime PlayingTime, double TicketsSold, double TicketPrice)
        //int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            this.CinemaID = CinemaID;
            this.MovieID = MovieID;
            this.PlayingTime = PlayingTime;
            this.TicketsSold = TicketsSold;
            this.TicketPrice = TicketPrice;
            //this.IsRemoved = isRemoved;
            //this.CreatedOn = createdOn;
            //this.UpdatedOn = updatedOn;
        }
    }
}
