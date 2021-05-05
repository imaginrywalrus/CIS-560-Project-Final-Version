using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesData.Models
{
    public class MovieDirector
    {
        public int DirectorID { get; }
        public int MovieID { get; }
        public double Salary { get; }
        //public int IsRemoved { get; }
        //public DateTime CreatedOn { get; }
        //public DateTime UpdatedOn { get; }

        public MovieDirector(int DirectorID, int MovieID, double Salary)
        //int isRemoved, DateTime createdOn, DateTime updatedOn)
        {
            this.DirectorID = DirectorID;
            this.MovieID = MovieID;
            this.Salary = Salary;
            //this.IsRemoved = isRemoved;
            //this.CreatedOn = createdOn;
            //this.UpdatedOn = updatedOn;
        }
    }
}
