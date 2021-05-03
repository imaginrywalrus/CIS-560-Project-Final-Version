using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class TotalSalesDataDelegate : DataReaderDelegate<double>
    {
        private readonly string movieName;

        public TotalSalesDataDelegate(string movieName)
           : base("Movies.TotalSales")
        {
            this.movieName = movieName;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("movieName", SqlDbType.NVarChar);
            p1.Value = movieName;
        }

        public override double Translate(SqlCommand command, IDataRowReader reader)
        {
            double salary = 0;
            if (!reader.HasRows())
            {
                return -1;
            }

            while (reader.Read()) { 
                salary = reader.GetDouble("TotalSales");
            }
            return salary;
        }
    }
}