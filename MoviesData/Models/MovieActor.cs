using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Models
{
    public class MovieActor
    {
        public int ActorID { get; }
        public int MovieID { get; }
        public double Salary { get; }
        //public int IsRemoved { get; }
        //public DateTime CreatedOn { get; }
        //public DateTime UpdatedOn { get; }

        public MovieActor(int ActorID, int MovieID, double Salary)
        //int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            this.ActorID = ActorID;
            this.MovieID = MovieID;
            this.Salary = Salary;
            //this.IsRemoved = isRemoved;
            //this.CreatedOn = createdOn;
            //this.UpdatedOn = updatedOn;
        }
    }
}
